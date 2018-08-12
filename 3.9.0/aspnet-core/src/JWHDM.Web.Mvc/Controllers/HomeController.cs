using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using JWHDM.Controllers;

namespace JWHDM.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : JWHDMControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
