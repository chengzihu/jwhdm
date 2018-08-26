using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JWHDM.Authorization;
using JWHDM.Controllers;
using JWHDM.Users;
using JWHDM.Web.Models.Users;
using Abp.Web.Models;
using System.Collections.Generic;
using System.Linq;
using Abp.Authorization;
using JWHDM.Users.Dto;
using Abp.AutoMapper;

namespace JWHDM.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : JWHDMControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        //public async Task<ActionResult> Index()
        //{
        //    var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
        //    var roles = (await _userAppService.GetRoles()).Items;
        //    var model = new UserListViewModel
        //    {
        //        Users = users,
        //        Roles = roles
        //    };
        //    return View(model);
        //}

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  获取GET参数 Request.Query["Key"] 获取POST参数 Request.Form["Key"]
        /// </summary>
        /// <returns></returns>
        [DontWrapResult] //不需要AbpJsonResult
        public async Task<ActionResult> GetUsers(UserQueryDto input)
        {
            //var tempPageNumber = Request.Query["pageNumber"].ToString();
            //var tempPageSize = Request.Query["pageSize"].ToString();
            ////HttpContextAccessorIns.HttpContext.Request
            //string pageNumber = string.IsNullOrWhiteSpace(tempPageNumber) ? "0" : tempPageNumber;
            //string pageSize = string.IsNullOrWhiteSpace(tempPageSize) ? "20" : tempPageSize;
            var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            //users=await _userAppService.get
            var userlist = users;
            if (!string.IsNullOrEmpty(input.departmentname))
                userlist = users.Where(x=>x.FullName.Contains(input.departmentname)).Skip(input.offset * input.limit).Take(input.limit).ToList();
            
            //var roles = (await _userAppService.GetRoles()).Items;
            //var model = new UserListViewModel
            //{
            //    Users = users,
            //    Roles = roles
            //};

            var result = new { total = userlist.Count(), rows = userlist };
            return Json(result);
        }

        //public async Task<JsonResult> EditUserModal(long id)
        //{
        //    var user = await _userAppService.Get(new EntityDto<long>(id));
        //    var roles = (await _userAppService.GetRoles()).Items;
        //    var model = new EditUserModalViewModel
        //    {
        //        User = user,
        //        Roles = roles
        //    };
        //    //return View("_EditUserModal", model);
        //    var data = new List<object>(){
        //        new {ID=1, Name="Arbet", Sex="男"},
        //        new {ID=2,  Name="Arbet1",Sex="女" },
        //        new {ID=3,  Name="Arbet2",Sex="男" },
        //        new {ID=4,  Name="Arbet3",Sex="女" },
        //        new {ID=5,  Name="Arbet4",Sex="男" },
        //        new {ID=6,  Name="Arbet5",Sex="男" },
        //        new {ID=7,  Name="Arbet6",Sex="女" },
        //        new {ID=8,  Name="Arbet7",Sex="男" },
        //        new {ID=9,  Name="Arbet1", Sex="女" },
        //        new {ID=10, Name="Arbet2",Sex="男" },
        //        new {ID=11, Name="Arbet3",Sex="女" },
        //        new {ID=12, Name="Arbet4",Sex="男" },
        //        new {ID=13, Name="Arbet5",Sex="男" },
        //        new {ID=14, Name="Arbet6",Sex="女" },
        //        new {ID=15, Name="Arbet7",Sex="男" }
        //    };
        //    var total = data.Count;
        //    var rows = data.Skip(0).Take(5).ToList();
        //    return Json(new { total = total, rows = rows });
        //}

        [DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> GetRoles()
        {
            //var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            //var model = new UserListViewModel
            //{
            //    Users = users,
            //    Roles = roles
            //};
            //var result = new { total = model.Users.Count, rows = model.Users };
            return Json(roles);
        }

        public async Task<JsonResult> Create([FromBody]CreateUserDto input)
        {
            //var userDto = viewModel.MapTo<CreateUserDto>();
            var user = await _userAppService.Create(input);
                return Json(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AbpAuthorize(PermissionNames.Pages_Users)]
        //[DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> Update([FromBody]UserDto input)
        {
            //var userDto = viewModel.MapTo<UserDto>();
            var user = await _userAppService.Update(input);
            return Json(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AbpAuthorize(PermissionNames.Pages_Users)]
        //[DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> Delete([FromBody]UsersDeleteDto viewModel)
        {
            var entityDto = viewModel.MapTo<EntityDto<long>>();
            await _userAppService.Delete(entityDto);
            return Json(entityDto);
        }

        //public async Task<ActionResult> EditUserModal(long userId)
        //{
        //    var user = await _userAppService.Get(new EntityDto<long>(userId));
        //    var roles = (await _userAppService.GetRoles()).Items;
        //    var model = new EditUserModalViewModel
        //    {
        //        User = user,
        //        Roles = roles
        //    };
        //    return View("_EditUserModal", model);
        //}
    }
}
