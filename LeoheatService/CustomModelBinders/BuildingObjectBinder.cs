using LeoheatService.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.CustomModelBinders
{
    public class BuildingObjectBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // Specify a default argument name if none is set by ModelBinderAttribute

            var modelName = bindingContext.BinderModelName;
            if (string.IsNullOrEmpty(modelName))
            {
                modelName = "id";
            }

            var valueProviderResult =
                bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            if (!int.TryParse(value, out var id))
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Id must be an int");
                return Task.CompletedTask;
            }

            var models = new List<BuildingObject>
            {
                new BuildingObject
                {
                    Id = 1,
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now - TimeSpan.FromDays(1),
                    HeatPumpPowerinKw = 10,
                    Location = "Lviv"
                },
                new BuildingObject
                {
                    Id = 2,
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now - TimeSpan.FromDays(20),
                    HeatPumpPowerinKw = 20,
                    Location = "Kyiv"
                }
            };
            var model = models.Find(a => a.Id == id);
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
