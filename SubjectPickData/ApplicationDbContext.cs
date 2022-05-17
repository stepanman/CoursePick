using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoursePickData.Models;
using CoursePickData.DbContextConfigurations;

namespace CoursePickData
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            new StudentEntityTypeConfiguration().Configure(builder.Entity<Student>());
            new CourseEntityTypeConfiguration().Configure(builder.Entity<Course>());
            new TutorEntityTypeConfiguration().Configure(builder.Entity<Tutor>());
        }
    }
}
