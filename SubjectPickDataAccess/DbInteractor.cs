using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursePickData;
using CoursePickData.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursePickDataAccess
{
    public class DbInteractor : IDbInteractor
    {
        private readonly ApplicationDbContext _context;
        public DbInteractor(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Course>> GetCoursesAsync()
        {
            return _context.Courses.Include(c => c.Tutor).ToListAsync();
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            return _context.Students.ToListAsync();
        }

        public Task<List<Tutor>> GetTutorsAsync()
        {
            return _context.Tutors.ToListAsync();
        }

        public Task<Course> GetCourseByIdAsync(int id)
        {
            return _context.Courses
                            .Include(c => c.Tutor)
                            .Include(c => c.Students)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            return _context.Students
                            .Include(s => s.Courses)
                            .ThenInclude(c => c.Tutor)
                            .FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<Student> GetStudentByEmailAsync(string email)
        {
            return _context.Students
                            .Include(s => s.Courses)
                            .ThenInclude(c => c.Tutor)
                            .FirstOrDefaultAsync(t => t.Email == email);

        }

        public Task<Tutor> GetTutorByIdAsync(int id)
        {
            return _context.Tutors
                            .Include(t => t.Courses)
                            .FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<Tutor> GetTutorByEmailAsync(string email)
        {
            return _context.Tutors
                            .Include(t => t.Courses)
                            .FirstOrDefaultAsync(t => t.Email == email);
        }

        public Task<List<Student>> GetStudentsOfTutorAsync(int id)
        {
            return _context.Students
                            .Include(s => s.Courses)
                            .Where(s => s.Courses.Select(c => c.TutorId).Contains(id))
                            .ToListAsync();
        }
    }
}
