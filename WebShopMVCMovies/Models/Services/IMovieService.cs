using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models.ViewModels;


namespace WebShopMVCMovies.Models.Services
{
   public interface IMovieService
    {
            Movie Create(CreateMovieViewModel createMovie);
            List<Movie> GetAll();
            List<Movie> Search(string search);
            Movie FindById(int id);
            bool Edit(int id, CreateMovieViewModel editMovie);
            void Remove(int id);
            MovieLanguageViewModel MovieLanguage(Movie movie);
            void RemoveLanguage(Movie movie, int languageId);
            void AddLanguage(Movie movie, int languageId);


        }
    }

