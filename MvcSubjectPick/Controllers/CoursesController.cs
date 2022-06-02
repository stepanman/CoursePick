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
    public class CoursesController : Controller
    {
        private readonly IDbInteractor _interactor;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CoursesController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _interactor = new DbInteractor(context);
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _interactor.GetCoursesAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            Course course = await _interactor.GetCourseByIdAsync((int)id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Tutor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,MaxStudents,Duration")] Course course)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _signInManager.UserManager.GetUserAsync(User);
                Tutor tutor = await _interactor.GetTutorByEmailAsync(user.Email);

                course.TutorId = tutor.Id;
                await _interactor.AddCourseAsync(course);
            }
            return View(course);
        }

/*        [Authorize(Roles = "Tutor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Course course = await _interactor.GetCourseByIdAsync((int)id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,MaxStudents,Duration,ImagePath,TutorId")] Course subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(subject.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/
    }
}
