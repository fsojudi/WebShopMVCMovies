using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models;
using WebShopMVCMovies.Models.Repos;
using WebShopMVCMovies.Models.Services;
using WebShopMVCMovies.Models.ViewModels;

namespace WebShopMVCMovies.Controllers
{
    public class MovieController : Controller
    {
        IMovieService _movieService;
        private readonly IDirectorService _directorService;
        public MovieController(IMovieService movieService, IDirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }
   
        public IActionResult Movie()
        {
            return View(_movieService.GetAll());
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create()
        {
            CreateMovieViewModel model = new CreateMovieViewModel();
            model.Directors = _directorService.GetAll();
            return View(model);

        }
        [HttpPost]
        public IActionResult Create(CreateMovieViewModel createMovie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.Create(createMovie);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name,Genre & Director", exception.Message);
                    return View(createMovie);
                }

                return RedirectToAction(nameof(Movie));
            }
            return View(createMovie);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie movie = _movieService.FindById(id);

            if (movie == null)
            {
                return RedirectToAction(nameof(Movie));
            }

            return View(movie);
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Movie movie = _movieService.FindById(id);

            if (movie == null)
            {
                return RedirectToAction(nameof(Movie));
            }
            CreateMovieViewModel editMovie = new CreateMovieViewModel()
            {
                Name = movie.Name,
                Genre = movie.Genre,
                DirectorId = movie.Id
            };
            editMovie.Directors = _directorService.GetAll();
            ViewBag.Id = id;

            return View(editMovie);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, CreateMovieViewModel editMovie)
        {

            if (ModelState.IsValid)
            {
                _movieService.Edit(id, editMovie);
                return RedirectToAction(nameof(Movie));
            }

            editMovie.Directors = _directorService.GetAll();
            ViewBag.Id = id;

            return View(editMovie);
        }

        public IActionResult Delete(int id)
        {
            Movie movie = _movieService.FindById(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Movie));
            }
            else
            {
                _movieService.Remove(id);

            }

            return View();
        }
        [HttpPost]
        public IActionResult Movie(string search)
        {
            if (search != null)
            {
                return View(_movieService.Search(search));
            }
            return RedirectToAction(nameof(Movie));
        }
        public IActionResult PersonLanguage(int id)
        {
            Movie movie = _movieService.FindById(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Movie));
            }
            return View(_movieService.MovieLanguage(movie));
        }

        public IActionResult AddLanguage(int movieId, int languageId)
        {
            Movie movie = _movieService.FindById(movieId);
            if (movie == null)
            {
                return RedirectToAction(nameof(Movie));
            }
            _movieService.AddLanguage(movie, languageId);
            return RedirectToAction(nameof(MovieLanguage), new { id = movie.Id });
        }

        public IActionResult RemoveLanguage(int movieId, int languageId)
        {
            Movie movie = _movieService.FindById(movieId);
            if (movie == null)
            {
                return RedirectToAction(nameof(Movie));
            }
            _movieService.RemoveLanguage(movie, languageId);
            return RedirectToAction(nameof(MovieLanguage), new { id = movie.Id });
        }

        //**********************************// AJAX //*******************************************//
        public IActionResult PartialViewMovie()
        {
            return PartialView("_MovieList", _movieService.GetAll());
        }
        [HttpPost]
        public IActionResult PartialViewDetails(int id)
        {
            Movie movie = _movieService.FindById(id);
            if (movie != null)
            {
                return PartialView("_MovieDetails", movie);
            }
            return NotFound();
        }
        public IActionResult AjaxDelete(int id)
        {
            Movie movie = _movieService.FindById(id);
            if (movie != null)
            {
                _movieService.Remove(id);
                return PartialView("_MovieList", _movieService.GetAll());
            }
            return NotFound();
        }

    }
}