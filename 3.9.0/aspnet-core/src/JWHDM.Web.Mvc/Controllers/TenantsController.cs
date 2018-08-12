using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JWHDM.Authorization;
using JWHDM.Controllers;
using JWHDM.MultiTenancy;
using JWHDM.MultiTenancy.Dto;
using Abp.Web.Models;
using JWHDM.Users.Dto;
using System.Linq;

namespace JWHDM.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : JWHDMControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        //public async Task<ActionResult> Index()
        //{
        //    var output = await _tenantAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue }); // Paging not implemented yet
        //    return View(output);
        //    //return Json(output);
        //}

        public async Task<ActionResult> Index()
        {
            //var output = await _tenantAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue }); // Paging not implemented yet
            return View();
        }

        [HttpGet]
        [DontWrapResult] //不需要AbpJsonResult]
        public async Task<JsonResult> GetTenants(RoleQueryDto input)
        {
            var output = (await _tenantAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var rolelist = output;
            if (!string.IsNullOrEmpty(input.departmentname))
                rolelist = output.Where(x => x.Name.Contains(input.departmentname) || x.TenancyName.Contains(input.departmentname)).Skip(input.offset * input.limit).Take(input.limit).ToList();
            var result = new { total = rolelist.Count, rows = rolelist };
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody]CreateTenantDto input)
        {
            var output = await _tenantAppService.Create(input);
            return Json(output);
        }

        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(long id)
        {
            var entityDto = new EntityDto<int> { Id = (int)id };
            await _tenantAppService.Delete(entityDto);
            return Json(entityDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AbpAuthorize(PermissionNames.Pages_Users)]
        //[DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> Update([FromBody]TenantDto input)
        {
            var output = await _tenantAppService.Update(input);
            return Json(output);
        }

        //[HttpPost]
        //public JsonResult Update(Contact contact)
        //{
        //    contactRepository.Post(contact);
        //    return Json(contactRepository.Get());
        //}

        //[HttpPost]
        //public JsonResult Delete(string id)
        //{
        //    var contact = contactRepository.Get(id);
        //    contactRepository.Delete(id);
        //    return Json(contactRepository.Get());
        //}

        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTenantModal(int tenantId)
        {
            var tenantDto = await _tenantAppService.Get(new EntityDto(tenantId));
            return View("_EditTenantModal", tenantDto);
        }
    }
}
