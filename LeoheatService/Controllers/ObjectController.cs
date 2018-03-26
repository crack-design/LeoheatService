using Leoheat.DAL.Entities;
using Leoheat.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.Controllers
{
    [Route("objects")]
    [Authorize]
    public class ObjectController : Controller
    {
        public JsonResult Get()
        {
            //return new JsonResult(this._unitOfWork.ObjectsRepository.Read());
            return new JsonResult("You got a list of objects");
        }

        public JsonResult GetObject(int id)
        {
            return new JsonResult($"You received object with id:{id}");
        }

        public IActionResult About()
        {
            return Content("You're authorized");
        }
    }
}
