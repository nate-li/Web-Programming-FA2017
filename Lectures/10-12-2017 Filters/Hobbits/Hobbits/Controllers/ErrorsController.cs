using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Hobbits.Services;
using Hobbits.Filters;

namespace Assignment3_2017.Controllers
{
    [TypeFilter(typeof(RequestIdFilter))]
    public class ErrorsController : Controller
    {
        private ILoggingService loggingService;

        public ErrorsController(ILoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        [Route("/Error")]
        public void Index()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;

            this.loggingService.Log(error?.ToString());

        }
    }
}
