using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoheatService.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;
        public CustomExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider,
            ILoggerFactory loggerFactory
            )
        {
            this._hostingEnvironment = hostingEnvironment;
            this._modelMetadataProvider = modelMetadataProvider;
            this._loggerFactory = loggerFactory;
            this._logger = loggerFactory.CreateLogger("ExceptionFilterLogger");
        }

        public override void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {
                return;
            }

            var result = new ViewResult();
            result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);

            this._logger.LogCritical(context.Exception, $"Unhandled exception from {context.HttpContext.Request.Path}");
            context.Result = result;
        }
    }
}
