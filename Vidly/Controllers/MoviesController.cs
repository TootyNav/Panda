using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Vidly.Migrations;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index(string searchString)
       {
            var movies = _context.Movies.Include(c => c.Genres).ToList();


            if (!string.IsNullOrEmpty(searchString))
            {
                movies = _context.Movies.Include(c => c.Genres).Where(s => s.Name.Contains(searchString)).ToList();

            }

            return View(movies);    
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genres).SingleOrDefault(c => c.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


        //New Movie
        public ActionResult New()
        {
            var genres = _context.Geners.ToList();
            //var movie = new Movie();
            var viewmodel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewmodel);
        }


        //The form is sent here
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Geners.ToList()
                };
                return View("MovieForm", viewModel);
            }




            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                //movieInDb.DateAdded = DateTime.Now;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenresId = movie.GenresId;

            }

            _context.SaveChanges();
                        
            return RedirectToAction("Index", "Movies");
        }


        //Click on a movie to edit it
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewmodel = new MovieFormViewModel(movie)
            {
                //Movie = movie,


                Genres = _context.Geners.ToList()
            };

            return View("MovieForm", viewmodel);
        }



        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id = 1, Name = "Shrek" },
        //        new Movie { Id = 2, Name = "Wall-e" }
        //    };
        //}
        

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var Customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Cutomer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = Customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "." + month);
        }
    }
}