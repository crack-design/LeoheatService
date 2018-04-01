using LeoheatService.CustomModelBinders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.ViewModels
{
    //[ModelBinder(BinderType = typeof(BuildingObjectBinder))]
    public class BuildingObject
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HeatPumpPowerinKw { get; set; }
    }
}
