using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Title")]
        public String Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Number Available")]
        public int NumberAvailable { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]        
        public decimal Price { get; set; }
    }
}