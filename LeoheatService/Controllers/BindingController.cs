using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.Controllers
{
    [Produces("application/json")]
    [Route("api/image")]
    public class BindingController : Controller
    {
        private readonly IHostingEnvironment _env;
        public BindingController(IHostingEnvironment env)
        {
            this._env = env;
        }
        [HttpPost]
        public void Post(byte[] file, string filename)
        {
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot/images/upload", filename);
            if (System.IO.File.Exists(filePath)) return;
            System.IO.File.WriteAllBytes(filePath, file);
        }

        [HttpPost("Profile")]
        public void SaveProfile(ProfileViewModel model)
        {
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot/images/upload", model.FileName);
            if (System.IO.File.Exists(model.FileName))
                return;
            System.IO.File.WriteAllBytes(filePath, model.File);
        }
    }

    public class ProfileViewModel
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
