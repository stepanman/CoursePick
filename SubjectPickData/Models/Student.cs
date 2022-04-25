using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SubjectPickData.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string Resume { get; set; }


        public ICollection<Subject> Subjects { get; set; }
    }
}
