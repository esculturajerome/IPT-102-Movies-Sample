using System;
using Microsoft.AspNetCore.Mvc;
using Week_7.Models;

namespace Week_7.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> _movies;

        public MoviesController()
        {
            // Sample movie data
            _movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Titanic", Rating = "5" },
                new Movie { Id = 2, Name = "Inception", Rating = "4" },
                new Movie { Id = 3, Name = "The Shawshank Redemption", Rating = "5" }
            };
        }

        // Get: /Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Titanic", Rating= "5" };
            return View(movie);
        }
        // Get: /Movies/Edit
        public ActionResult Get(int id)
        {
            var movie = _movies.Find(m => m.Id == id);

            if (movie == null)
                return NotFound(); // Return 404 if movie not found

            return View(movie);

        }
        // /Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}