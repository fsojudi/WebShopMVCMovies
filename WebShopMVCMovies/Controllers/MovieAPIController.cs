using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models;
using WebShopMVCMovies.Models.Services;
using WebShopMVCMovies.Models.ViewModels;


namespace WebShopMVCMovies.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieAPIController : ControllerBase
    {

        private readonly IMovieService _movieService;
        public MovieAPIController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public IEnumerable<Movie> Get()
        {

            IEnumerable<Movie> list = _movieService.GetAll();

            foreach (var item in list)
            {
                item.Director.Movies = null;
                item.Director.Country.Directors = null;
            }

            return list;
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            Movie movie = _movieService.FindById(id);
            movie.Director.Movies = null;
            movie.Director.Country.Directors = null;
            foreach (var item in movie.MovieLanguages)
            {
                item.movie.MovieLanguages = null;
                if (item.Language != null)
                {
                    item.Language.MovieLanguages = null;
                }
            }
            return movie;

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Post([FromBody] CreateMovieViewModel createMovie)
        {
            Movie movie = _movieService.Create(createMovie);
            if (movie != null)
            {
                Response.StatusCode = 201;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateMovieViewModel editMovie)
        {
            _movieService.Edit(id, editMovie);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _movieService.Remove(id);
        }
    }
}