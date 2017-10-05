using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarryPotterMvc.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/Error")]
        public void Index()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = feature?.Error;
          
            Console.Write(exception);
        }
    }
}
