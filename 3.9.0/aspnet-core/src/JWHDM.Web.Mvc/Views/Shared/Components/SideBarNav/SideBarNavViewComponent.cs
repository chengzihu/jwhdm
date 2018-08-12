using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Navigation;
using Abp.Runtime.Session;

namespace JWHDM.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewComponent : JWHDMViewComponent
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IAbpSession _abpSession;

        public SideBarNavViewComponent(
            IUserNavigationManager userNavigationManager,
            IAbpSession abpSession)
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
        }

        //public async Task<IViewComponentResult> InvokeAsync(string activeMenu = "")
        //{
        //    var model = new SideBarNavViewModel
        //    {
        //        MainMenu = await _userNavigationManager.GetMenuAsync("MainMenu", _abpSession.ToUserIdentifier()),
        //        ActiveMenuItemName = activeMenu
        //    };
        //    return View(model);
        //}

        public async Task<IViewComponentResult> InvokeAsync(SideBarNavViewModel allUserMenu,UserMenuItem userMenuItem, string activeMenu = "")
        {
            if (allUserMenu == null)
            {
                var wholeModel = new SideBarNavViewModel
                {
                    MainMenu = await _userNavigationManager.GetMenuAsync("MainMenu", _abpSession.ToUserIdentifier()),
                    ActiveMenuItemName = activeMenu
                };
                return View(wholeModel);
            }
            var model = new SideBarNavViewModel
            {
                MainMenu = new UserMenu
                {
                    DisplayName = userMenuItem.DisplayName,
                    CustomData = userMenuItem.CustomData,
                    Name = userMenuItem.Name,
                    Items = userMenuItem.Items,
                },
                ActiveMenuItemName = activeMenu
            };
            return View(model);
        }
    }
}
