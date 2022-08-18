using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopMVCMovies.Models.ViewModels
{
    public class CreateMovieViewModel
    {

        [Display(Name = "Movie Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public string Genre { get; set; }

        [Display(Name = "Director")]
        [Required]
        public int DirectorId { get; set; }
        [Display(Name = "Price")]
        public string Price { get; set; }

        public List<Director> Directors { get; set; }
    }
}