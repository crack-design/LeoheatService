﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeoheatService.Controllers
{
    public class HomeController : Controller
    {
        const string SessionKeyName = "_Name";
        const string SessionKeyYearsMember = "_YearsMember";
        const string SessionKeyDate = "_Date";

        public IActionResult Index()
        {
            // Requires using Microsoft.AspNetCore.Http;
            return RedirectToAction("SessionNameYears");
        }
        public IActionResult SessionNameYears()
        {

            return Content("In Home controller");
        }
    }
}