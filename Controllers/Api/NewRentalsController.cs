﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            var Price = newRental.Price;

            foreach(var movie in movies)
            {
                if(movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available.");
                }

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    Price = movie.Price,
                    DateRented = DateTime.Now
                };

                movie.NumberAvailable--;

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}