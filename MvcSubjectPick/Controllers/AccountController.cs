using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursePick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using CoursePickDataAccess;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CoursePickData;

namespace CoursePick.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IDbInteractor _dbInteractor;

        public AccountController(SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _dbInteractor = new DbInteractor(context);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, Password")] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _signInManager.UserManager.FindByEmailAsync(model.Email);

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Details()
        {
            IdentityUser user = _signInManager.UserManager.GetUserAsync(User).Result;
            if (User.IsInRole("Student"))
            {
                return RedirectToAction("Details", "Students", new { _dbInteractor.GetStudentByEmailAsync(user.Email).Result.Id });
            }
            else if (User.IsInRole("Tutor"))
            {
                return RedirectToAction("Details", "Tutors", new { _dbInteractor.GetTutorByEmailAsync(user.Email).Result.Id });
            }
            else
                return RedirectToAction(nameof(Index));
        }

    }
}
