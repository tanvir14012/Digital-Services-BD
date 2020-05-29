using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Digital_Services_BD.Controllers
{
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        public AdminController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductGroup()
        {
            return View();
        }
    }
}
