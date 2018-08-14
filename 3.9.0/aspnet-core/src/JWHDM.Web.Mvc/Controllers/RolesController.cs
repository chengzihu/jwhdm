using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JWHDM.Authorization;
using JWHDM.Controllers;
using JWHDM.Roles;
using JWHDM.Web.Models.Roles;
using Abp.Web.Models;
using JWHDM.Roles.Dto;
using Abp.AutoMapper;
using JWHDM.Users.Dto;
using System.Linq;
using Abp.Authorization;

namespace JWHDM.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    public class RolesController : JWHDMControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto())).Items;
            var permissions = (await _roleAppService.GetAllPermissions()).Items;

            foreach (var role in roles)
            {
                var grantedPermissions = (await _roleAppService.GetGrantedPermissionsAsync(role.Id));
                role.Permissions.Clear();
                role.Permissions.AddRange(grantedPermissions);
            }

            var model = new RoleListViewModel
            {
                Roles = roles,
                Permissions = permissions
            };

            return View(model);
        }

        [DontWrapResult] //不需要AbpJsonResult]
        public async Task<JsonResult> GetRoles(RoleQueryDto input)
        {
            var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto() {  SkipCount= input.offset * input.limit, MaxResultCount= input.limit})).Items;
            var rolelist = roles;
            if (!string.IsNullOrEmpty(input.departmentname))
                rolelist = roles.Where(x => x.Name.Contains(input.departmentname) || x.DisplayName.Contains(input.departmentname)).ToList();//.Skip(input.offset * input.limit).Take(input.limit).ToList();

            foreach (var role in rolelist)
            {
                var grantedPermissions = (await _roleAppService.GetGrantedPermissionsAsync(role.Id));
                role.Permissions.Clear();
                role.Permissions.AddRange(grantedPermissions);
            }

            var result = new { total = rolelist.Count, rows = rolelist };
            return Json(result);
        }

        //[HttpPost]
        [ValidateAntiForgeryToken]
        //[AbpAuthorize(PermissionNames.Pages_Users)]
        //[DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> Delete(long id)
        {
            var entityDto = new EntityDto<int>{Id=(int)id};
            await _roleAppService.Delete(entityDto);
            return Json(entityDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create([FromBody]CreateRoleDto input)
        {
            var role = await _roleAppService.Create(input);
            return Json(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AbpAuthorize(PermissionNames.Pages_Users)]
        //[DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> Update([FromBody]RoleDto input)
        {
            var role = await _roleAppService.Update(input);
            return Json(role);
        }

        [ValidateAntiForgeryToken]
        //[DontWrapResult] //不需要AbpJsonResult]
        public async Task<ActionResult> EditRoleModal(int roleId)
        {
            var role = await _roleAppService.Get(new EntityDto(roleId));
            var grantedPermissions = (await _roleAppService.GetGrantedPermissionsAsync(role.Id));
            role.Permissions.Clear();
            role.Permissions.AddRange(grantedPermissions);

            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new EditRoleModalViewModel
            {
                Role = role,
                Permissions = permissions
            };
            return PartialView("_EditRoleModal", model);
        }
    }
}
