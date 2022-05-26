using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursePickIdentityData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoursePickDataSeeding
{
    public class IdentityDbSeeder : IDbSeeder
    {
        private readonly ApplicationIdentityDbContext _context;
        public IdentityDbSeeder(ApplicationIdentityDbContext context)
        {
            _context = context;
        }
        public async Task Seed()
        {
            if (_context.Users.Any())
                return;


            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(_context);
            await roleStore.CreateAsync(new IdentityRole { Name = "Student", NormalizedName = "STUDENT"});
            await roleStore.CreateAsync(new IdentityRole { Name = "Tutor", NormalizedName = "TUTOR"});


            IdentityUser[] students = new IdentityUser[]
            {
                new IdentityUser
                {
                    UserName = "Zahrai Denys",
                    Email = "denzahrai@gmail.com"
                },
                new IdentityUser
                {
                    UserName = "Doe Fred",
                    Email = "fredidog@gmail.com"
                },
                new IdentityUser
                {
                    UserName = "Musk Elon",
                    Email = "elonmusk@spacex.com"
                },
                new IdentityUser
                {
                    UserName = "Zuckerberg Mark",
                    Email = "zuckerberg@facebook.com"
                },
                new IdentityUser
                {
                    UserName = "Ballmer Steve",
                    Email = "mrballmer@gmail.com"
                },
                new IdentityUser
                {
                    UserName = "Bloomberg Michael",
                    Email = "bloombloom6@gmail.com"
                }
            };

            IdentityUser[] tutors = new IdentityUser[]
            {
                new IdentityUser
                {
                    UserName = "Avramenko Svitlana",
                    Email = "rydivna@lnu.edu.ua",
                },
                new IdentityUser
                {
                    UserName = "Babenko Galyna",
                    Email = "galbabenko@lnu.edu.ua",
                },
                new IdentityUser
                {
                    UserName = "Doe Denys",
                    Email = "doedoedoe@gmail.com",
                },
                new IdentityUser
                {
                    UserName = "Banah Taras",
                    Email = "taraspetrovych@lnu.edu.ua",
                },
                new IdentityUser
                {
                    UserName = "Benzyk Roman",
                    Email = "benzyk215@yahoo.com",
                }
            };

            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(_context);


            foreach (IdentityUser user in students)
            {
                user.NormalizedUserName = user.UserName.ToUpper();
                user.NormalizedEmail = user.Email.ToUpper();
                user.PasswordHash = hasher.HashPassword(user, "password");
                await userStore.AddToRoleAsync(user, "STUDENT");
                await userStore.CreateAsync(user);
            }

            foreach(IdentityUser user in tutors)
            {
                user.NormalizedUserName = user.UserName.ToUpper();
                user.NormalizedEmail = user.Email.ToUpper();
                user.PasswordHash = hasher.HashPassword(user, "password");
                await userStore.AddToRoleAsync(user, "TUTOR");
                await userStore.CreateAsync(user);
            }
        }
    }
}
