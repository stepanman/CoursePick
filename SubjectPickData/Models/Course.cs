﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePickData.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public uint MaxStudents { get; set; }
        public uint Duration { get; set; }

        public ICollection<Student> Students { get; set; }

        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
    }
}
