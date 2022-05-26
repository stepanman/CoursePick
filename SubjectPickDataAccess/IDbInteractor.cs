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
        Task<List<Course>> GetCoursesAsync();
        Task<List<Student>> GetStudentsAsync();
        Task<List<Tutor>> GetTutorsAsync();



        Task<Course> GetCourseByIdAsync(int id);

        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> GetStudentByEmailAsync(string email);
        
        Task<Tutor> GetTutorByIdAsync(int id);
        Task<Tutor> GetTutorByEmailAsync(string email);


        Task<List<Student>> GetStudentsOfTutorAsync(int id);
    }
}
