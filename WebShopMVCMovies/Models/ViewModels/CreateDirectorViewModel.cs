using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopMVCMovies.Models.ViewModels
{
    public class CreateDirectorViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Director Name")]
        public string DirectorName { get; set; }
        public List<Movie> MovieList { get; set; }
        public int CountryId { get; set; }
        public List<Country> Countries { get; set; }

        public CreateDirectorViewModel() { Countries = new List<Country>(); }


    }
}


