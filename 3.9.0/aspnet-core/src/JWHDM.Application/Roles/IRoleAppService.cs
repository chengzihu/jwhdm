using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using JWHDM.Roles.Dto;

namespace JWHDM.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<List<string>> GetGrantedPermissionsAsync(int roleId);

        List<Permission> GetRolePermissionsForManage();
    }
}
