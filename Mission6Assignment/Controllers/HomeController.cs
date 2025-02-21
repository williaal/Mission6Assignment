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
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult movieform(Movie response)
        {
            _context.Movies.Add(response); //add record to database
            _context.SaveChanges();

            return View("Confirmation");
        }

        public IActionResult MovieList()
        {
            //var movies = _context.Movies.ToList();
            //var categories = _context.Categories.ToList();

            var movies = _context.Movies
                .Join(_context.Categories,
                      movie => movie.CategoryId,
                      category => category.CategoryId,
                      (movie, category) => new
                      {
                          movie.MovieId,
                          movie.Title,
                          movie.Year,
                          CategoryName = category.CategoryName,
                          movie.Director,
                          movie.Rating,
                          movie.Edited,
                          movie.LentTo,
                          movie.CopiedToPlex,
                          movie.Notes
                      })
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();
            return View("movieform", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                    .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            var recordToDelete = _context.Movies.SingleOrDefault(x => x.MovieId == movie.MovieId);

            if (recordToDelete != null)
            {
                _context.Movies.Remove(recordToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }
    }
}