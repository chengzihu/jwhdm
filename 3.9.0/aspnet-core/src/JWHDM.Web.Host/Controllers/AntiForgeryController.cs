using Microsoft.AspNetCore.Antiforgery;
using JWHDM.Controllers;

namespace JWHDM.Web.Host.Controllers
{
    public class AntiForgeryController : JWHDMControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
