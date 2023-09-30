using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesIndexViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}