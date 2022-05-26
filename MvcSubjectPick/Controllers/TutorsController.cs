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

namespace CoursePick.Controllers
{
    [Authorize]
    public class TutorsController : Controller
    {
        private readonly IDbInteractor _interactor;

        public TutorsController(ApplicationDbContext context)
        {
            _interactor = new DbInteractor(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _interactor.GetTutorsAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var tutor = await _interactor.GetTutorByIdAsync((int)id);

            if (tutor == null)
                return NotFound();

            return View(tutor);
        }
    }
}
