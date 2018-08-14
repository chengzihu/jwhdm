using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JWHDM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWHDM.UserMember
{
    public class UserMemberAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>, IUserMemberAppService
    {
        //Task<ListResultDto<RoleDto>> GetRoles();

        //Task ChangeLanguage(ChangeUserLanguageDto input);
        public Task<UserDto> Create(CreateUserDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Get(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<UserDto>> GetAll(PagedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Update(UserDto input)
        {
            throw new NotImplementedException();
        }
    }
}
