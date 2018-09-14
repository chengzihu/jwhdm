using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using JWHDM.UserMemberLessonMinds.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMemberLessonMinds
{
    public class UserMemberLessonMindAppService : AsyncCrudAppService<UserMemberLessonMind, UserMemberLessonMindDto, long, GetUserMemberLessonMindsPagedResultRequestInput, CreateUserMemberLessonMindInput, UpdateUserMemberLessonMindInput>, IUserMemberLessonMindAppService
    {
        private readonly IRepository<UserMemberLessonMind, long> _userMemberLessonMindRepository;
        public UserMemberLessonMindAppService(IRepository<UserMemberLessonMind, long> userMemberLessonMindRepository) :base(userMemberLessonMindRepository)
        {
            this._userMemberLessonMindRepository = userMemberLessonMindRepository;
        }

        public async Task<PagedResultDto<UserMemberLessonMindDto>> GetAllIncluding(GetUserMemberLessonMindsPagedResultRequestInput input)
        {
            var queryUserMembers = _userMemberLessonMindRepository.GetAllIncluding(u => u.UserMember,u=>u.LessonMind);//.Skip(Convert.ToInt32(input.Number)*input.SkipCount).Take(input.SkipCount);
            //queryUserMembers = !string.IsNullOrEmpty(input.Name) ? queryUserMembers.Where(x => x.Name.Contains(input.Name)) : queryUserMembers;
            //queryUserMembers = !string.IsNullOrEmpty(input.Number) ? queryUserMembers.Where(x => x.Number.Contains(input.Number)) : queryUserMembers;
            var total = queryUserMembers.Count();
            var resultDomain = await queryUserMembers.PageBy(input).ToListAsync();
            var userMemberDtoList = resultDomain.MapTo<List<UserMemberLessonMindDto>>();
            var resultDto = new PagedResultDto<UserMemberLessonMindDto>(total, userMemberDtoList);
            return resultDto;
        }

        public override Task<UserMemberLessonMindDto> Create(CreateUserMemberLessonMindInput input)
        {
            if (AbpSession.TenantId.HasValue)
            {
                input.TenantId = AbpSession.TenantId.Value;
            }
            if (AbpSession.UserId.HasValue)
            {
                input.CreatorUserId = AbpSession.UserId.Value;
            }

            return base.Create(input);
        }

        public override Task<UserMemberLessonMindDto> Update(UpdateUserMemberLessonMindInput input)
        {
            if (AbpSession.TenantId.HasValue)
            {
                input.TenantId = AbpSession.TenantId.Value;
            }
            if (AbpSession.UserId.HasValue)
            {
                input.CreatorUserId = AbpSession.UserId.Value;
            }
            return base.Update(input);
        }

        public override Task Delete(EntityDto<long> input)
        {
            return base.Delete(input);
        }
    }
}
