using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using JWHDM.UserMembers.Dto;
using JWHDM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMembers
{
    public interface IUserMemberAppService : IAsyncCrudAppService<UserMemberDto,long, GetUserMembersPagedResultRequestDto, CreateUserMemberDto, UpdateUserMemberDto>//, IApplicationService
    {
        //Task<ListResultDto<RoleDto>> GetRoles();

        //Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<PagedResultDto<UserMemberDto>> GetAllIncluding(GetUserMembersPagedResultRequestDto input);
    }
}
