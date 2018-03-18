using Leoheat.DAL.Entities;
using Leoheat.DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.Controllers
{
    [Route("objects")]
    public class ObjectController : Controller
    {
        //private IUnitOfWork _unitOfWork;
        //public ObjectController(IUnitOfWork unitOfWork)
        //{
        //    this._unitOfWork = unitOfWork;
        //}
        [HttpGet]
        public JsonResult Get()
        {
            //return new JsonResult(this._unitOfWork.ObjectsRepository.Read());
            return new JsonResult("You got a list of objects");
        }

        [HttpGet("{id}")]
        public JsonResult GetObject(int id)
        {
            return new JsonResult($"You received object with id:{id}");
        }
    }
}
