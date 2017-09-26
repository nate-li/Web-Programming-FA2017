using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StudentsLecture.Controllers
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // api/Students
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        public static List<Student> students = new List<Student>();

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            return Json(students[id]);
        }

        [HttpPost]
        public Student Post([FromBody] Student student)
        {
            students.Add(student);

            return student;
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] Student student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int) HttpStatusCode.NotFound);
            }

            students[id] = student;

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
