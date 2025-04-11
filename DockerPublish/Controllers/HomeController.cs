using DockerPublish.Data;
using DockerPublish.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace DockerPublish.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetStudent() => View(await _context.Student.ToListAsync());

        public IActionResult CreateStudent() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Student person)
        {
            if (!ModelState.IsValid) return View(person);
            _context.Student.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetStudent));
        }
    }
}
