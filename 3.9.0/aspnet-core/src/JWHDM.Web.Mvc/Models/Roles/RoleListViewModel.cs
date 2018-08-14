using System.Collections.Generic;
using JWHDM.Roles.Dto;

namespace JWHDM.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }

        //add by kevin at 18.08.14
        public IReadOnlyList<PermissionDto> GrantedPermissions { get; set; }
    }
}
