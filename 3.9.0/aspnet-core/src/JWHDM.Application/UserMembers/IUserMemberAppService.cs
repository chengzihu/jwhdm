using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JWHDM.UserMembers.Dto;
using JWHDM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.UserMembers
{
    public interface IUserMemberAppService : IAsyncCrudAppService<UserMemberDto, long, GetUserMembersPagedResultRequestDto, CreateUserMemberDto, UserMemberDto>
    {
        //Task<ListResultDto<RoleDto>> GetRoles();

        //Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
