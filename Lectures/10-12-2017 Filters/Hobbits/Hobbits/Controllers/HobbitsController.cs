using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hobbits.Entities;
using Hobbits.Services;
using System.Net;
using Hobbits.Filters;

namespace Hobbits.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(RequestIdFilter))]
    [TypeFilter(typeof(ModelStateFilter))]
    public class HobbitsController : Controller
    {
        private HobbitDatabase hobbits;

        private ILoggingService loggingService;

        public HobbitsController(HobbitDatabase hobbits, ILoggingService loggingService)
        {
            this.hobbits = hobbits;
            this.loggingService = loggingService;
        }

        [HttpGet("{id}")]
        public HobbitEntity Get(int id)
        {
            return hobbits.Get(id).ToEntity();
        }

        [HttpPost]
        public IActionResult Post([FromBody]HobbitEntity hobbit)
        {
            if (hobbits.Add(hobbit.ToModel()))
            {
                this.loggingService.Log("A hobbit was added.");
                return Json(hobbit);

            } else
            {
                this.loggingService.Log("The id was invalid for the request.");

                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Could not add your hobbit"
                };
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]HobbitEntity hobbit)
        {
            if (hobbits.Add(hobbit.ToModel(), id))
            {
                return Json(hobbit);
            }
            else
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Your hobbit index was invalid."
                };
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            hobbits.Delete(id);
        }
    }
}
