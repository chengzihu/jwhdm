using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JWHDM.Roles.Dto;
using JWHDM.Users.Dto;

namespace JWHDM.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
