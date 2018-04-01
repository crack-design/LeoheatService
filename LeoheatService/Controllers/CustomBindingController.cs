using LeoheatService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomBindingController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetById(BuildingObject model)
        {
            if (model == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(model);
        }
    }
}
