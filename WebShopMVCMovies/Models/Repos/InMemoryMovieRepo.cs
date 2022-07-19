using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopMVCMovies.Models.Repos
{
    public class InMemoryMovieRepo : IMovieRepo
    {
        private static List<Movie> movieList = new List<Movie>();
        private static int idCounter = 0;

        public Movie Create(Movie movie )
        {
            movie.Id = ++idCounter;
            movieList.Add(movie);

            return movie;
        }

        public List<Movie> GetAll()
        {
            return movieList;
        }

        public Movie GetById(int id)
        {
            Movie movie = null;
            foreach (Movie thisMovie in movieList)
            {
                if (thisMovie.Id == id)
                {
                    movie = thisMovie;
                    break;

                }
            }
            return movie;
        }

        public bool Update(Movie movie)
        {
            Movie orgMovie = GetById(movie.Id);
            if (orgMovie == null)
            {
                return false;
            }
            else
            {
                orgMovie.Name = movie.Name;
                orgMovie.Genre = movie.Genre;
                orgMovie.Director = movie.Director;

                return true;
            }
        }
        public void Delete(Movie movie)
        {
            movieList.Remove(movie);
        }


    }
}