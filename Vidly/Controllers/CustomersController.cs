using System;
using System.Data.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Customers
		public ActionResult Index()
        {
			var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

			return View(customers);
        }

		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c=>c.MembershipType).FirstOrDefault(c => c.Id == id);

			return View(customer);
		}

		public ActionResult New()
		{
			var viewModel = new NewCustomerViewModel {
				MembershipTypes = _context.MembershipTypes.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(NewCustomerViewModel viewModel)
		{
			return View();
		}

    }
}