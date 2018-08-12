using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace JWHDM.Web.Views
{
    public abstract class JWHDMRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected JWHDMRazorPage()
        {
            LocalizationSourceName = JWHDMConsts.LocalizationSourceName;
        }
    }
}
