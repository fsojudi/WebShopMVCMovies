using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopMVCMovies.Models
{
    public class Country
    {

        [Key]
        public int Id { get; set; }
        public List<Director> Directors { get; set; }
        public string CountryName { get; set; }
        public Country(string countryName) { CountryName = countryName; }
        public Country()
        { }

    }
}
