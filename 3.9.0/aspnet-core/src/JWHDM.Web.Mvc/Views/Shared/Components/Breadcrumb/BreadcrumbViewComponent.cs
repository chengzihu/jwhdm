using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Configuration;
using JWHDM.Configuration;
using JWHDM.Configuration.Ui;

namespace JWHDM.Web.Views.Shared.Components.Breadcrumb
{
    public class BreadcrumbViewComponent : JWHDMViewComponent
    {
        private readonly ISettingManager _settingManager;

        public BreadcrumbViewComponent(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var themeName = await _settingManager.GetSettingValueAsync(AppSettingNames.UiTheme);

            var viewModel = new BreadcrumbViewModel
            {
                CurrentTheme = UiThemes.All.FirstOrDefault(t => t.CssClass == themeName)
            };

            return View(viewModel);
        }
    }
}
