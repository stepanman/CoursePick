using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectPickData.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxStudents { get; set; }
        public TimeSpan Duration { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Student> Students { get; set; }

        public Guid TutorId { get; set; }
        public Tutor Tutor { get; set; }
    }
}
