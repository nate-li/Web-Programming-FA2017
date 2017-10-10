using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace Assignment3_2017.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/Error")]
        public void Index()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;

            Console.Write(error);
        }
    }
}
