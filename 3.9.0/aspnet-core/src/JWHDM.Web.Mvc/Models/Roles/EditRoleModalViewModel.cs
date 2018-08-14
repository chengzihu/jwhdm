using System.Collections.Generic;
using System.Linq;
using JWHDM.Roles.Dto;

namespace JWHDM.Web.Models.Roles
{
    public class EditRoleModalViewModel
    {
        public RoleDto Role { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }

        public bool HasPermission(PermissionDto permission)
        {
            var has = Permissions != null && Role.Permissions.Any(p => p == permission.Name);
            return has;
        }
    }
}
