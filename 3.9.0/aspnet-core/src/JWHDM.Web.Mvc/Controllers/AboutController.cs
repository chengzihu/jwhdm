using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using JWHDM.Controllers;

namespace JWHDM.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : JWHDMControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
