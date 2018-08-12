using Abp.AspNetCore.Mvc.ViewComponents;

namespace JWHDM.Web.Views
{
    public abstract class JWHDMViewComponent : AbpViewComponent
    {
        protected JWHDMViewComponent()
        {
            LocalizationSourceName = JWHDMConsts.LocalizationSourceName;
        }
    }
}
