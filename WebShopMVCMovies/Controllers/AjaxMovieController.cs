using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models;
using WebShopMVCMovies.Models.Repos;
using WebShopMVCMovies.Models.Services;

namespace WebShopMVCMovies.Controllers
{
    public class AjaxMovieController : Controller
    {
        IMovieService _movieService;

        public AjaxMovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SpaMovieList()
        {
            return PartialView("_SpaMovieList", _movieService.GetAll());
        }

        public IActionResult SpaMovieDetails(int id)
        {
            Movie movie = _movieService.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return PartialView("_SpaMovieDetails", movie);
        }
        public IActionResult SpaMovieRow(int id)
        {
            Movie movie = _movieService.FindById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return PartialView("_SpaMovieRow", movie);
        }
        public IActionResult SpaAjaxDelete(int id)
        {
            Movie movie = _movieService.FindById(id);
            if (movie != null)
            {
                _movieService.Remove(id);
                return PartialView("_SpaMovieList", _movieService.GetAll());
            }
            return NotFound();
        }
    }
}