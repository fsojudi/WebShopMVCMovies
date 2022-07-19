using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models;
using WebShopMVCMovies.Data;
using WebShopMVCMovies.Models.Repos;
using Microsoft.EntityFrameworkCore;

namespace WebShopMVCMovies.Data
{
    public class DatabasMovieRepo : IMovieRepo
    {
        readonly MovieDbContext _movieDbContext;
        public DatabasMovieRepo(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public Movie Create(Movie movie)
        {
            _movieDbContext.Movies.Add(movie);
            _movieDbContext.SaveChanges();

            return movie;
        }


        public List<Movie> GetAll()
        {
            return _movieDbContext.Movies.Include(movie => movie.Director).ThenInclude(movie => movie.Country).Include(movie => movie.MovieLanguages).ToList();

        }

        public Movie GetById(int id)
        {
            return _movieDbContext.Movies.Include(movie => movie.Director).ThenInclude(movie => movie.Country).Include(movie => movie.MovieLanguages).SingleOrDefault(movie => movie.Id == id);
        }

        public bool Update(Movie movie)
        {
            _movieDbContext.Movies.Update(movie);
            int result = _movieDbContext.SaveChanges();
            if (result == 0)
            {
                return false;

            }
            return true;
        }
        public void Delete(Movie movie)
        {
            _movieDbContext.Movies.Remove(movie);
            _movieDbContext.SaveChanges();


        }
    }
}