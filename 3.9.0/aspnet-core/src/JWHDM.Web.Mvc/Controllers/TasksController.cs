using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWHDM.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace JWHDM.Web.Mvc.Controllers
{
    public class TasksController : JWHDMControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}