using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeoheatService.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        const string SessionKeyName = "_Name";
        const string SessionKeyYearsMember = "_YearsMember";
        const string SessionKeyDate = "_Date";

        [AllowAnonymous]
        public IActionResult Index()
        {
            // Requires using Microsoft.AspNetCore.Http;
            return RedirectToAction("SessionNameYears");
        }
        public IActionResult SessionNameYears()
        {

            return Content("In Home controller");
        }

        
        public IActionResult About()
        {
            return Content("In action that requires authorization");
        }
    }
}
