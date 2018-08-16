using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.AutoMapper;
using Abp.Web.Models;
using JWHDM.Authorization;
using JWHDM.Controllers;
using JWHDM.UserMembers;
using JWHDM.UserMembers.Dto;
using JWHDM.Users;
using JWHDM.Users.Dto;
using JWHDM.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace JWHDM.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_UserMembers)]
    public class UserMembersController:JWHDMControllerBase
    {
        private readonly IUserMemberAppService _userMemberAppService;

        public UserMembersController(IUserMemberAppService userMemberAppService)
        {
            _userMemberAppService = userMemberAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Pages_UserMembers_Query, PermissionNames.Pages_Pages_UserMembers_Create)]
        /// <summary>
        ///  获取GET参数 Request.Query["Key"] 获取POST参数 Request.Form["Key"]
        /// </summary>
        /// <returns></returns>
        [DontWrapResult] //不需要AbpJsonResult
        public async Task<ActionResult> GetUserMembers(QueryUserMemberDto input)
        {
            var users = (await _userMemberAppService.GetAll(new GetUserMembersPagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            //users=await _userAppService.get
            var userlist = users;
            //if (!string.IsNullOrEmpty(input.departmentname))
            //    userlist = users.Where(x => x.FullName.Contains(input.departmentname)).Skip(input.offset * input.limit).Take(input.limit).ToList();

            var result = new { total = userlist.Count(), rows = userlist };
            return Json(result);
        }

        ////[DontWrapResult] //不需要AbpJsonResult
        ////public async Task<JsonResult> GetRoles()
        ////{
        ////    var roles = (await _userMemberAppService.GetRoles()).Items;
        ////    return Json(roles);
        ////}

        //public async Task<JsonResult> Create([FromBody]CreateUserDto input)
        //{
        //    var user = await _userMemberAppService.Create(input);
        //    return Json(user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<JsonResult> Update([FromBody]UserDto input)
        //{
        //    var user = await _userMemberAppService.Update(input);
        //    return Json(user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<JsonResult> Delete([FromBody]UsersDeleteDto viewModel)
        //{
        //    var entityDto = viewModel.MapTo<EntityDto<long>>();
        //    await _userMemberAppService.Delete(entityDto);
        //    return Json(entityDto);
        //}
    }
}