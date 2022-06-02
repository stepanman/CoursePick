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
        public Task<List<Course>> GetAllCoursesAsync();

        public Task<List<Course>> GetCoursesOfTutorAsync(int tutorId);

        public Task<List<Student>> GetAllStudentsAsync();

        public Task<List<Student>> GetStudentsOfTutorAsync(int tutorId);

        public Task<List<Tutor>> GetAllTutorsAsync();

        public Task<Course> GetCourseByIdAsync(int id);

        public Task<bool> CourseExists(int id);

        public Task<bool> CourseWithSameTitleExistsAsync(string title);

        public Task<Student> GetStudentByIdAsync(int id);

        public Task<Student> GetStudentByEmailAsync(string email);

        public Task<Tutor> GetTutorByIdAsync(int id);

        public Task<Tutor> GetTutorByEmailAsync(string email);

        public Task<int> AddCourseAsync(Course course);
    }
}
