using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Net;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {   
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rental
        public IEnumerable<RentalDto> GetRentals()
        {
            return _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.Id == id);

            if (rental == null)
                return NotFound();

            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        [HttpPut]
        public void ReturnRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(r => r.Id == id);
            //var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == rentalInDb.Movie.Id);

            if (rentalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            rentalInDb.DateReturned = DateTime.Now;
            //movieInDb.NumberAvailable++;

            _context.SaveChanges();
        }
    }
}