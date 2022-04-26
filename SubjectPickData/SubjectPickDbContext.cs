using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubjectPickData.Models;
using SubjectPickData.DbContextConfigurations;

namespace SubjectPickData
{
    public class SubjectPickDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        public SubjectPickDbContext(DbContextOptions<SubjectPickDbContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            new StudentEntityTypeConfiguration().Configure(builder.Entity<Student>());
            new SubjectEntityTypeConfiguration().Configure(builder.Entity<Subject>());
            new TutorEntityTypeConfiguration().Configure(builder.Entity<Tutor>());
        }
    }
}
