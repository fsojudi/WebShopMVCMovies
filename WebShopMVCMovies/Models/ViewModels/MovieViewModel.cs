using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebShopMVCMovies.Models.ViewModels
{
    public class MovieViewModel
    {

            public List<Movie> MovieListView { get; set; }

            public string FilterString { get; set; }

            public MovieViewModel()
            { MovieListView = new List<Movie>(); }

        }
    }
