﻿using System;
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

		public ActionResult Index()
		{
			var movies = new List<Movie> {
				new Movie { Name = "Skrek!" },
				new Movie { Name = "Wall-e" }
				};

			return View(movies);
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

		public ActionResult Edit(int movieId)
		{
			return Content("id=" + movieId);
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