using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int NumberAvailable { get; set; }
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public double Price { get; set; }
    }
}