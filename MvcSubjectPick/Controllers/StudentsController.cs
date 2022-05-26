using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursePickData;
using CoursePickData.Models;
using CoursePickDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CoursePick.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IDbInteractor _interactor;
        private readonly SignInManager<IdentityUser> _signInManager;

        public StudentsController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _interactor = new DbInteractor(context);
            _signInManager = signInManager;
        }

        [Authorize(Roles = "Tutor")]
        public async Task<IActionResult> Index()
        {
            IdentityUser user = await _signInManager.UserManager.GetUserAsync(User);
            Tutor tutor = await _interactor.GetTutorByEmailAsync(user.Email);
            return View(await _interactor.GetStudentsOfTutorAsync(tutor.Id));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student student = await _interactor.GetStudentByIdAsync((int)id);

            if (student == null)
                return NotFound();

            return View(student);
        }
    }
}
