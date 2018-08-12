using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Configuration;
using JWHDM.Configuration;
using JWHDM.Configuration.Ui;
using Abp.Application.Navigation;
using Abp.Runtime.Session;

namespace JWHDM.Web.Views.Shared.Components.MainHeader
{
    public class MainHeaderViewComponent : JWHDMViewComponent
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IAbpSession _abpSession;

        public MainHeaderViewComponent(IUserNavigationManager userNavigationManager,
            IAbpSession abpSession)
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
        }

        public async Task<IViewComponentResult> InvokeAsync(string activeMenu = "")
        {
            var viewModel = new MainHeaderViewModel
            {
                CurrentTheme = ""
            };

            return View(viewModel);
        }
    }
}
