using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopMVCMovies.Models
{

    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }

        public Movie()
        { }
        public Movie(string name)
        {
            Name = name;
        }
        [ForeignKey(nameof(Director))]
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public List<MovieLanguage> MovieLanguages { get; set; }

    }
}