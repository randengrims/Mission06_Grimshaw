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
            return View(new Application());
        }

        [HttpPost]
        public IActionResult MovieForm(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Applications.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else // invaldidate the data
            {
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
            var applications = _context.Applications
                .Where(x => x.Edited == false)
                .OrderBy(x => x.Title).ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Applications
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
            var recordToDelete = _context.Applications
                .Single(x => x.MovieId == id);

            return View("DeleteView", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application application)
        {
            _context.Applications.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("Waitlist");
        }
    }
}