using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6Assignment.Models;

namespace Mission6Assignment.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context;
        public HomeController(MovieFormContext temp) //Constructur
        {
            _context = temp;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult knowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult movieform()
        {
            return View();
        }
        [HttpPost]
        public IActionResult movieform(Application response)
        {
            _context.Applications.Add(response); //add record to database
            _context.SaveChanges();

            return View("Confirmation");
        }
    }
}
