using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWHDM.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace JWHDM.Web.Mvc.Controllers
{
    public class Tasks2Controller : JWHDMControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}