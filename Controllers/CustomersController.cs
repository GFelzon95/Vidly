using System;
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

        List<Customer> _customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };
        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomersIndexViewModel
            {
                Customers = _customers
            };

            return View(viewModel);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomersDetailsViewModel
            {
                Customer = customer
            };
            return View(viewModel);
        }
    }
}