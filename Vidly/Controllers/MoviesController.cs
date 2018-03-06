using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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


		public ActionResult Index()
		{
			var movies = _context.Movies.Include(m=>m.Genre).ToList();

			return View(movies);
		}

		public ActionResult Add()
		{
			var genres = _context.Genres.ToList();
			var viewModel = new MovieFormViewModel
			{
				Genres = genres
			};
			return View("MovieForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.Single(m => m.Id == id);
			if (movie == null) return new HttpNotFoundResult();
			var genres = _context.Genres.ToList();

			var viewModel = new MovieFormViewModel
			{
				Movie = movie,
				Genres = genres
			};
			return View("MovieForm", viewModel);
		}

		[HttpPost]
		public ActionResult Save(Movie movie)
		{
			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);

			} else
			{
				var movieFromDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
				if (movieFromDb != null)
				{
					movieFromDb.GenreId = movie.GenreId;
					movieFromDb.Name = movie.Name;
					movieFromDb.NumberInStock = movie.NumberInStock;
					movieFromDb.ReleaseDate = movie.ReleaseDate;
				}

			}
			try
			{
				_context.SaveChanges();
			} catch (DbEntityValidationException e)
			{
				Console.WriteLine(e);
			}
			
			return RedirectToAction("Index", "Movies");
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Where(m => m.Id == id).Include(m => m.Genre).SingleOrDefault();
			return View(movie);
		}

        // GET: Movies
        public ActionResult Random()
        {
			var movie = new Movie
			{
				Name = "Skrek!"
			};

			var customers = new List<Customer> {
				new Customer { Name = "Customer 1" },
				new Customer { Name = "Customer 2" }
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

            return View(viewModel);
        }

		[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
		public ActionResult ByReleaseYear(int year, int month)
		{
			return Content(year + "/" + month);
		}

		public ActionResult IndexOLD(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue) pageIndex = 1;

			if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

			return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex, sortBy));
		}

		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}

	}

	
}