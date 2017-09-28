using Microsoft.AspNetCore.Mvc;
using StudentsLecture.Entities;
using StudentsLecture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StudentsLecture.Controllers
{

    // api/Students
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        public static List<StudentModel> students = new List<StudentModel>();

        [HttpGet]
        public IEnumerable<StudentEntity> Get()
        {
            return students.Select(sm => sm.ToEntity());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            return Json(students[id].ToEntity());
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentEntity student)
        {
            if (student.FirstName?.Length == 0 || student.LastName?.Length == 0)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Your model did not validate correctly. Ensure that your FirstName/LastName are long enough."
                };
            }

            students.Add(student.ToModel());

            return Json(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] StudentEntity student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int) HttpStatusCode.NotFound);
            }
            
            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Your model did not validate correctly. Ensure that your FirstName/LastName are long enough."
                };
            }

            students[id] = student.ToModel();

            return new JsonResult(student);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            students.RemoveAt(id);

            return new StatusCodeResult((int)HttpStatusCode.NoContent);
        }
    }
}
