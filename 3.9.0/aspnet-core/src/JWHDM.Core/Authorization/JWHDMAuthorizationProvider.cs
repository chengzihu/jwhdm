using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace JWHDM.Authorization
{
    public class JWHDMAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            //if (pages == null)
            //{
            //    pages = context.CreatePermission(PermissionNames.Pages,L("Pages"));
            //}

            var users= context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            var roles= context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            var tenants= context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var userMembers=context.CreatePermission(PermissionNames.Pages_UserMembers, L("UserMembers"));
            userMembers.CreateChildPermission(PermissionNames.Pages_UserMembers_Query, L("UserMembers.Query"));
            userMembers.CreateChildPermission(PermissionNames.Pages_UserMembers_Create, L("UserMembers.Create"));
            userMembers.CreateChildPermission(PermissionNames.Pages_UserMembers_Update, L("UserMembers.Update"));
            userMembers.CreateChildPermission(PermissionNames.Pages_UserMembers_Delete, L("UserMembers.Delete"));

            //context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            //context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            //context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            //context.CreatePermission(PermissionNames.Pages_UserMembers,L("UserMembers"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, JWHDMConsts.LocalizationSourceName);
        }
    }
}
