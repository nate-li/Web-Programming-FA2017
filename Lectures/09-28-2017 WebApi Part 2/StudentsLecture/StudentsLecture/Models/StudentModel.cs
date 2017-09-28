using StudentsLecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsLecture.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdministrator { get; set; }

        public StudentEntity ToEntity()
        {
            return new StudentEntity()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                IsAdministrator = this.IsAdministrator
            };
        }
    }
}
