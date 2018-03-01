using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> Movies = new List<Movie>
        {
            new Movie {Id = 1, Name = "Shrek"},
            new Movie {Id = 2, Name = "Toy Story"}
        };

        // GET: Movies
        public ActionResult Random()
        {

            Movie Movie = new Movie()
            {
                Name = "Shrek"
            };

            List<Customer> customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            RandomMovieViewModel viewModel = new RandomMovieViewModel
            {
                Movie = Movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex = 1, string sortBy = "name")
        {
            return View(Movies);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            Movie movie = Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            {
                return View(movie);
            }

            return HttpNotFound();
        }
    }
}