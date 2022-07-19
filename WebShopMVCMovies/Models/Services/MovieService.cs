using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models.Repos;
using WebShopMVCMovies.Models.ViewModels;

namespace WebShopMVCMovies.Models.Services
{
    public class MovieService:IMovieService
    {

        IMovieRepo _movieRepo;
        private readonly ILanguageRepo _languageRepo;
        public MovieService(IMovieRepo movieRepo, ILanguageRepo languageRepo)
        {
            _movieRepo = movieRepo;
            _languageRepo = languageRepo;
        }
        public Movie Create(CreateMovieViewModel createMovie)
        {

            if (string.IsNullOrWhiteSpace(createMovie.Name))

            {
                throw new ArgumentException("Movie Name,Genre or Director, Cannot be consist of backspace(s)/whitespace(s)");
            }
            Movie movie = new Movie()
            {
                Name = createMovie.Name,
                Genre = createMovie.Genre,
                DirectorId = createMovie.DirectorId
            };
            _movieRepo.Create(movie);
            return movie;
        }
        public List<Movie> GetAll()
        {
            return _movieRepo.GetAll();
        }

        public List<Movie> Search(string search)
        {
            List<Movie> searchMovie = _movieRepo.GetAll();
            
            foreach (Movie item in _movieRepo.GetAll())
            {
                if (item.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    searchMovie.Add(item);
                }
            }
            if (searchMovie.Count == 0)
            {
                throw new ArgumentException("Could not find what you where looking for");
            }
            return searchMovie;
        }
        public Movie FindById(int id)
        {
            Movie foundMovie = _movieRepo.GetById(id);

            return foundMovie;
        }
        public bool Edit(int id, CreateMovieViewModel editMovie)
        {
            Movie movie = _movieRepo.GetById(id);
            if (movie != null)
            {
                movie.Name = editMovie.Name;
                movie.DirectorId = editMovie.DirectorId;
                movie.Genre = editMovie.Genre;
            }
            return _movieRepo.Update(movie);
        }

        public void Remove(int id)
        {
            Movie movieToDelete = _movieRepo.GetById(id);
            if (movieToDelete != null)
            {
                _movieRepo.Delete(movieToDelete);
            }
        }

        public MovieLanguageViewModel MovieLanguage(Movie movie)
        {

            MovieLanguageViewModel movieLanguage = new MovieLanguageViewModel();
            movieLanguage.Movie = movie;
            List<Language> allLanguages = _languageRepo.GetAll();

            foreach (MovieLanguage mLanguage in movie.MovieLanguages)
            {
                Language language = allLanguages.Single(l => l.Id == mLanguage.LanguageId);
                // l= is a short version for "language"
                movieLanguage.SpeakesLanguage.Add(language);
                allLanguages.Remove(language);
            }
            movieLanguage.AllLanguages = allLanguages;
            return movieLanguage;


        }

        public void RemoveLanguage(Movie movie, int languageId)
        {
            MovieLanguage language = movie.MovieLanguages.SingleOrDefault(pL => pL.LanguageId == languageId);
            // pL= is short version for peoleLanguage
            movie.MovieLanguages.Remove(language);
            _movieRepo.Update(movie);
        }

        public void AddLanguage(Movie movie, int languageId)
        {
            MovieLanguage language = new MovieLanguage()
            {
                LanguageId = languageId,
                MovieId = movie.Id
            };

            movie.MovieLanguages.Add(language);

            _movieRepo.Update(movie);
        }
    }
}


