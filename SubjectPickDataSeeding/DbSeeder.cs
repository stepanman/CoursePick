using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoursePickData;
using CoursePickData.Models;

namespace CoursePickDataSeeding
{
    public class DbSeeder : IDbSeeder
    {
        private readonly ApplicationDbContext _context;
        public DbSeeder(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Seed()
        {

            if (_context.Courses.Any())
                return;

            Student[] students = new Student[]
            {
                new Student
                {
                    Surname = "Zahrai",
                    Name = "Denys",
                    Email = "denzahrai@gmail.com",
                    ImagePath = "users-photos/DenysZahrai.jpg",
                    Resume = "I am a student"

                },
                new Student
                {
                    Surname = "Doe",
                    Name = "Fred",
                    Email = "fredidog@gmail.com",
                    ImagePath = "users-photos/FredDoe.jpg",
                    Resume = "I am a student"
                },
                new Student
                {
                    Surname = "Musk",
                    Name = "Elon",
                    Email = "elonmusk@spacex.com",
                    ImagePath = "users-photos/ElonMusk.jpg",
                    Resume = "I am a student"
                },
                new Student
                {
                    Surname = "Zuckerberg",
                    Name = "Mark",
                    Email = "zuckerberg@facebook.com",
                    ImagePath = "users-photos/MarkZuckerberg.jpg",
                    Resume = "I am a student"
                },
                new Student
                {
                    Surname = "Ballmer",
                    Name = "Steve",
                    Email = "mrballmer@gmail.com",
                    ImagePath = "users-photos/SteveBallmer.jpg",
                    Resume = "I am a student"
                },
                new Student
                {
                    Surname = "Bloomberg",
                    Name = "Michael",
                    Email = "bloombloom6@gmail.com",
                    ImagePath = "users-photos/MichaelBloomberg.jpg",
                    Resume = "I am a student"
                }
            };

            Course[] courses = new Course[]
            {
                new Course
                {
                    Title = "Digital Marketing",
                    Description = "Course about digital marketing",
                    MaxStudents = 40,
                    Duration = 12,
                    Students = new List<Student>()
                },
                new Course
                {
                    Title = "Social Media",
                    Description = "Course about social media",
                    MaxStudents = 50,
                    Duration = 8,
                    Students = new List<Student>()
                },
                new Course
                {
                    Title = "Data Science",
                    Description = "Course about data science",
                    MaxStudents = 25,
                    Duration = 16,
                    Students = new List<Student>()
                },
                new Course
                {
                    Title = "Data Analytics",
                    Description = "Course about data analytics",
                    MaxStudents = 50,
                    Duration = 10,
                    Students = new List<Student>()
                },
                new Course
                {
                    Title = "Cybersecurity",
                    Description = "Course about cybersecurity",
                    MaxStudents = 45,
                    Duration = 22,
                    Students = new List<Student>()
                },
                new Course
                {
                    Title = "UI/UX Design",
                    Description = "Course about UI/UI design",
                    MaxStudents = 65,
                    Duration = 15,
                    Students = new List<Student>()
                },
                new Course
                {
                    Title = "Project Management",
                    Description = "Course about project mamangement",
                    MaxStudents = 50,
                    Duration = 12,
                    Students = new List<Student>()
                },
                new Course
                {
                    Title = "IT Support",
                    Description = "Course about IT support",
                    MaxStudents = 30,
                    Duration = 12,
                    Students = new List<Student>()
                },
            };

            Tutor[] tutors = new Tutor[]
            {
                new Tutor
                {
                    Surname = "Avramenko",
                    Name = "Svitlana",
                    Email = "rydivna@lnu.edu.ua",
                    BirthDate = new DateTime(1974, 7, 27),
                    Resume = "I am a tutor",
                    ImagePath = "users-photos/SvitlanaAvramenko.jpg"
                },
                new Tutor
                {
                    Surname = "Babenko",
                    Name = "Galyna",
                    Email = "galbabenko@lnu.edu.ua",
                    BirthDate = new DateTime(1986, 11, 22),
                    Resume = "I am a tutor",
                    ImagePath = "users-photos/GalynaBabenko.jpg"
                },
                new Tutor
                {
                    Surname = "Doe",
                    Name = "Denys",
                    Email = "doedoedoe@gmail.com",
                    BirthDate = new DateTime(1977, 7, 7),
                    Resume = "I am a tutor",
                    ImagePath = "users-photos/DenysDoe.jpg"
                },
                new Tutor
                {
                    Surname = "Banah",
                    Name = "Taras",
                    Email = "taraspetrovych@lnu.edu.ua",
                    BirthDate = new DateTime(1959, 5, 3),
                    Resume = "I am a tutor",
                    ImagePath = "users-photos/TarasBanah.jpg"
                },
                new Tutor
                {
                    Surname = "Benzyk",
                    Name = "Roman",
                    Email = "benzyk215@yahoo.com",
                    BirthDate = new DateTime(1993, 12, 15),
                    Resume = "I am a tutor",
                    ImagePath = "users-photos/RomanBenzyk.jpg"
                },
            };

            await _context.Courses.AddRangeAsync(courses);

            courses[0].Tutor = tutors[0];
            courses[0].Students.Add(students[0]);
            courses[0].Students.Add(students[2]);
            courses[0].Students.Add(students[4]);
            courses[0].Students.Add(students[5]);

            courses[1].Tutor = tutors[0];
            courses[1].Students.Add(students[1]);
            courses[1].Students.Add(students[2]);
            courses[1].Students.Add(students[3]);
            courses[1].Students.Add(students[5]);

            courses[2].Tutor = tutors[1];
            courses[2].Students.Add(students[0]);
            courses[2].Students.Add(students[1]);
            courses[2].Students.Add(students[3]);
            courses[2].Students.Add(students[2]);

            courses[3].Tutor = tutors[2];
            courses[3].Students.Add(students[1]);
            courses[3].Students.Add(students[2]);
            courses[3].Students.Add(students[4]);
            courses[3].Students.Add(students[5]);

            courses[4].Tutor = tutors[2];
            courses[4].Students.Add(students[1]);
            courses[4].Students.Add(students[3]);
            courses[4].Students.Add(students[4]);
            courses[4].Students.Add(students[5]);

            courses[5].Tutor = tutors[3];
            courses[5].Students.Add(students[0]);
            courses[5].Students.Add(students[1]);
            courses[5].Students.Add(students[2]);
            courses[5].Students.Add(students[3]);

            courses[6].Tutor = tutors[4];
            courses[6].Students.Add(students[1]);
            courses[6].Students.Add(students[3]);
            courses[6].Students.Add(students[4]);
            courses[6].Students.Add(students[5]);

            courses[7].Tutor = tutors[4];
            courses[7].Students.Add(students[0]);
            courses[7].Students.Add(students[1]);
            courses[7].Students.Add(students[3]);
            courses[7].Students.Add(students[4]);

            await _context.SaveChangesAsync();
        }
    }
}
