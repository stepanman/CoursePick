using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePickData.Models
{
    public class Tutor
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Resume { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
