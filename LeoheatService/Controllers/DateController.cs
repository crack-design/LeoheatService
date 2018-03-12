using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeoheatService.SessionsExtensions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeoheatService.Controllers
{
    public class DateController : Controller
    {
        private string SessionsKeyDate = String.Empty;

        public IActionResult SetDate()
        {
            // Requires you add the Set extension method mentioned in the article.
            SessionExtensions.Set(HttpContext.Session, SessionsKeyDate, DateTime.Now);
            return RedirectToAction("GetDate");
        }

        public IActionResult GetDate()
        {
            // Requires you add the Get extension method mentioned in the article.
            var date = SessionExtensions.Get<DateTime>(HttpContext.Session, SessionsKeyDate);
            var sessionTime = date.TimeOfDay.ToString();
            var currentTime = DateTime.Now.TimeOfDay.ToString();

            return Content($"Current time: {currentTime} - "
                         + $"session time: {sessionTime}");
        }
    }
}
