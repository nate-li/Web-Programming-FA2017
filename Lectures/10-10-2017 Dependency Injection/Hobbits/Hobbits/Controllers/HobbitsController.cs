using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hobbits.Models;
using Hobbits.Services;
using System.Net;

namespace Hobbits.Controllers
{
    [Route("api/[controller]")]
    public class HobbitsController : Controller
    {

        private static HobbitDatabase hobbits = new HobbitDatabase();

        [HttpGet("{id}")]
        public HobbitEntity Get(int id)
        {
            return hobbits.Get(id).ToEntity();
        }

        [HttpPost]
        public IActionResult Post([FromBody]HobbitEntity hobbit)
        {
            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Check to ensure the structure of your JSON hobbit."
                };
            }
            hobbits.Add(hobbit.ToModel());

            return Json(hobbit);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]HobbitEntity hobbit)
        {
            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Check to ensure the structure of your JSON hobbit."
                };
            }
            hobbits.Add(hobbit.ToModel(), id);

            return Json(hobbit);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            hobbits.Delete(id);
        }
    }
}
