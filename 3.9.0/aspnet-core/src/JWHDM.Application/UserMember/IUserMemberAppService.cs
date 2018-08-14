using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JWHDM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.UserMember
{
    public interface IUserMemberAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        //Task<ListResultDto<RoleDto>> GetRoles();

        //Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
