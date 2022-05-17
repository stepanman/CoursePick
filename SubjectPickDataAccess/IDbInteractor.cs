using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursePickData.Models;

namespace CoursePickDataAccess
{
    public interface IDbInteractor
    {
        Task EnrollStudentAsync(Student student);
        Task ExpelStudentAsync(Student student);

        Task HireTutorAsync(Tutor tutor);
        Task FireTutorAsync(Tutor tutor);

        Task AddCourseAsync(Course course);
        Task CancelCourseAsync(Course course);

        Task EnrollStudentInCourseAsync(Student student, Course course);
        Task ExpelStudentFromCourseAsync(Student student, Course course);
        Task AssignTutorToCourseAsync(Tutor tutor, Course course);
    }
}
