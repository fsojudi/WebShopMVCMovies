using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models.ViewModels;

namespace WebShopMVCMovies.Models.Repos
{
    public interface IMovieRepo
    {
       

        Movie Create(Movie movie); 

        
        List<Movie> GetAll();

        Movie GetById(int id); 


       
        bool Update(Movie movie); 


      
        void Delete(Movie movie);
    }
}