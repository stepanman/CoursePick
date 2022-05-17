using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursePickData;
using CoursePickData.Models;

namespace CoursePickDataAccess
{
    public class DbInteractor : IDbInteractor
    {
        private readonly ApplicationDbContext _context;
        public DbInteractor(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task EnrollStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
        public async Task ExpelStudentAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task HireTutorAsync(Tutor tutor)
        {
            await _context.Tutors.AddAsync(tutor);
            await _context.SaveChangesAsync();
        }
        public async Task FireTutorAsync(Tutor tutor)
        {
            _context.Tutors.Remove(tutor);
            await _context.SaveChangesAsync();
        }



        public async Task AddCourseAsync(Course course)
        {
            await _context.AddAsync(course);
            await _context.SaveChangesAsync();
        }
        public async Task CancelCourseAsync(Course course)
        {
            _context.Remove(course);
            await _context.SaveChangesAsync();
        }


        public async Task EnrollStudentInCourseAsync(Student student, Course course)
        {
            _context.Courses.FirstOrDefault(c => c == course).Students.Add(student);
            await _context.SaveChangesAsync();

        }
        public async Task ExpelStudentFromCourseAsync(Student student, Course course)
        {
            _context.Courses.FirstOrDefault(c => c == course).Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task AssignTutorToCourseAsync(Tutor tutor, Course course)
        {
            _context.Courses.FirstOrDefault(c => c == course).Tutor = tutor;
            await _context.SaveChangesAsync();
        }
    }
}
