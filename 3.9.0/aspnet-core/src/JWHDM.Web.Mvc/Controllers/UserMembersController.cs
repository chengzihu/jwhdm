using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using Abp.Json;
using Abp.Runtime.Session;
using Abp.Web.Models;
using JWHDM.Authorization;
using JWHDM.Controllers;
using JWHDM.LessonMinds;
using JWHDM.UserMemberLessonMinds;
using JWHDM.UserMemberLessonMinds.Dto;
using JWHDM.UserMembers;
using JWHDM.UserMembers.Dto;
using JWHDM.Users;
using JWHDM.Users.Dto;
using JWHDM.Web.Models.UserMembers;
using JWHDM.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace JWHDM.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_UserMembers)]
    public class UserMembersController:JWHDMControllerBase
    { 
        private IUserMemberAppService _userMemberAppService;
        private IUserMemberLessonMindAppService _userMemberLessonMindAppService;
        private ILessonMindsAppService _lessonMindsAppService;

        public UserMembersController(IUserMemberAppService userMemberAppService,
            IUserMemberLessonMindAppService userMemberLessonMindAppService,
            ILessonMindsAppService lessonMindsAppService)
        {
            AbpSession = NullAbpSession.Instance;
            _userMemberAppService = userMemberAppService;
            _userMemberLessonMindAppService = userMemberLessonMindAppService;
            _lessonMindsAppService = lessonMindsAppService;
        }

        public async Task<ActionResult> Index()
        {
            _lessonMindsAppService.SeedData();
            var lessonMindDtos =(await _lessonMindsAppService.GetAll(new QueryLessonMindDto{ MaxResultCount = int.MaxValue })).Items;
            var model = new UserMemberListViewModel {
                LessonMinds = lessonMindDtos
            };
            return View(model);
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Pages_UserMembers_Query, PermissionNames.Pages_Pages_UserMembers_Create)]
        /// <summary>
        ///  获取GET参数 Request.Query["Key"] 获取POST参数 Request.Form["Key"]
        /// </summary>
        /// <returns></returns>
        [DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> GetUserMembers(GetUserMembersPagedResultRequestDto input)
        {
            input.MaxResultCount = input.limit;
            input.SkipCount = input.limit * input.offset;
            var users = (await _userMemberAppService.GetAllIncluding(input)).Items; // Paging not implemented yet
            
            //users=await _userAppService.get
            //if (!string.IsNullOrEmpty(input.departmentname))
            //    userlist = users.Where(x => x.FullName.Contains(input.departmentname)).Skip(input.offset * input.limit).Take(input.limit).ToList();

            var resultJson = Json(new { total = users.Count(), rows = users });
            return resultJson;
        }

        //[HttpPost]
        [ValidateAntiForgeryToken]
        //[AbpAuthorize(PermissionNames.Pages_Users)]
        //[DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> Delete(long id)
        {
            var entityDto = new EntityDto<long>(id);
            await _userMemberAppService.Delete(entityDto);
            return Json(entityDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create([FromBody]CreateUserMemberDto input)
        {
            var userMemberCreated = await _userMemberAppService.Create(input);
            return Json(userMemberCreated);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AbpAuthorize(PermissionNames.Pages_Users)]
        //[DontWrapResult] //不需要AbpJsonResult
        public async Task<JsonResult> Update([FromBody]UpdateUserMemberDto input)
        {
            UserMemberDto role = null;
            try
            {
                role = await _userMemberAppService.Update(input);
            }
            catch (Exception e)
            {

            }
            return Json(role);
        }

        [ValidateAntiForgeryToken]
        //[DontWrapResult] //不需要AbpJsonResult]
        public async Task<ActionResult> EditModal(long userMemberId)
        {
            var userMember = await _userMemberAppService.GetIncluding(userMemberId);
            var lessonMinds =await _lessonMindsAppService.GetAll(new QueryLessonMindDto {  MaxResultCount=int.MaxValue,limit=int.MaxValue});
            var model = new EditUserMemberModalViewModel
            {
                 UserMember= userMember,
                LessonMinds =lessonMinds.Items,
            };
            return PartialView("_EditModal", model);
        }
    }
}