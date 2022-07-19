using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopMVCMovies.Models
{
    public class Director
    {


        [Key]
        public int Id { get; set; }

        public Director()
        { }

        public Director(string directorName) { DirectorName = directorName; }
        [Required]
        [MaxLength(80)]
        public string DirectorName { get; set; }
        public List<Movie> Movies { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
