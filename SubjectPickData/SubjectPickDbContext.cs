using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SubjectPickData
{
    public class SubjectPickDbContext : DbContext
    {
        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Models.Subject> Subjects { get; set; }
        public DbSet<Models.Tutor> Tutors { get; set; }

        public SubjectPickDbContext(DbContextOptions<SubjectPickDbContext> options) : base(options)
        {

        }
    }
}
