using Abp.Authorization;
using JWHDM.Authorization.Roles;
using JWHDM.Authorization.Users;

namespace JWHDM.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
