using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectPickData.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SubjectPickDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SubjectPickDbContext>>()))
            {
                // Look for any movies.
                if (context.Tutors.Any())
                {
                    return;   // DB has been seeded
                }
                context.Tutors.AddRange(
                    new Tutor
                    {
                        Surname = "Voytovych",
                        Name = "Maxym",
                        Email = "maxym.voytovych@gmail.com",
                        BirthDate = new DateTime(2001,11,23),
                        Resume = "Ok tutor"
                    }
                    ,
                    new Tutor
                    {
                        Surname = "Mazuryk",
                        Name = "Stepan",
                        Email = "stepan.mazuryk@gmail.com",
                        BirthDate = new DateTime(2002, 5, 17),
                        Resume = "also ok tutor"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
