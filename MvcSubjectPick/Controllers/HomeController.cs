using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoursePick.Models;
using System;
using System.Diagnostics;
using CoursePickData;
using CoursePickIdentityData;
using CoursePickDataSeeding;
using System.Threading.Tasks;

namespace CoursePick.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ApplicationIdentityDbContext _identityContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ApplicationIdentityDbContext identityContext)
        {
            _logger = logger;
            _context = context;
            _identityContext = identityContext;
        }

        public async Task<IActionResult> Index()
        {
            IDbSeeder seeder;
            seeder = new DbSeeder(_context);
            await seeder.Seed();
            seeder = new IdentityDbSeeder(_identityContext);
            await seeder.Seed();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
