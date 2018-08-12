using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace JWHDM.Controllers
{
    public abstract class JWHDMControllerBase: AbpController
    {
        protected JWHDMControllerBase()
        {
            LocalizationSourceName = JWHDMConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
