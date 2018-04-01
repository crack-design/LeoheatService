using LeoheatService.SessionsExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.Controllers
{
    public class SessionController : Controller
    {
        const string SessionKeyName = "_Name";
        const string SessionKeyYearsMember = "_YearsMember";
        const string SessionKeyDate = "_Date";

        public IActionResult Index()
        {
            // Requires using Microsoft.AspNetCore.Http;
            HttpContext.Session.SetString(SessionKeyName, "Rick");
            HttpContext.Session.SetInt32(SessionKeyYearsMember, 3);
            return RedirectToAction("SessionNameYears");
        }
        public IActionResult SessionNameYears()
        {
            var name = HttpContext.Session.GetString(SessionKeyName);
            var yearsMember = HttpContext.Session.GetInt32(SessionKeyYearsMember);

            return Content($"Name: \"{name}\",  Membership years: \"{yearsMember}\"");
        }

        public IActionResult SetDate()
        {
            // Requires you add the Set extension method mentioned in the article.
            HttpContext.Session.Set<DateTime>(SessionKeyDate, DateTime.Now);
            return RedirectToAction("GetDate");
        }

        public IActionResult GetDate()
        {
            // Requires you add the Get extension method mentioned in the article.
            var date = HttpContext.Session.Get<DateTime>(SessionKeyDate);
            var sessionTime = date.TimeOfDay.ToString();
            var currentTime = DateTime.Now.TimeOfDay.ToString();

            return Content($"Current time: {currentTime} - "
                         + $"session time: {sessionTime}");
        }

        public IActionResult GetUserAgent()
        {
            return Content($"{HttpContext.Items["user-agent"]}");

        // technique used to avoid duplicate keys across apps
                //public static readonly object SampleKey = new Object();

                //public async Task Invoke(HttpContext httpContext)
                //{
                //    httpContext.Items[SampleKey] = "some value";
                //    // additional code omitted
                //}
    }
    }
}
