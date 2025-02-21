using System.Diagnostics;
using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context;
        public HomeController(MovieFormContext temp) 
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", new Application());
        }

        [HttpPost]
        public IActionResult MovieForm(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else // invaldidate the data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }

        }
        
        // Get to know Joel Page
        public IActionResult KnowJoel() 
        {
            return View();
        }

        public IActionResult Waitlist()
        {
            var applications = _context.Movies
                .Where(x => x.Edited == false)
                .OrderBy(x => x.Title).ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            return View("MovieForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Waitlist");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View("DeleteView", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("Waitlist");
        }
    }
}