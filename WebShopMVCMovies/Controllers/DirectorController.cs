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
    public class DirectorController : Controller
    {

        private IDirectorService _directorService;
        private ICountryService _countryService;
        public DirectorController(IDirectorService directorService, ICountryService countryService)
        {
            _directorService = directorService;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            return View(_directorService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateDirectorViewModel model = new CreateDirectorViewModel();
            model.Countries = _countryService.All();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateDirectorViewModel createDirector)
        {
            if (ModelState.IsValid)
            {
                _directorService.Create(createDirector);
                return RedirectToAction(nameof(Index));
            }
            return View(createDirector);
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Director director = _directorService.FindById(Id);
            if (director == null)
            {

                return RedirectToAction(nameof(Index));
            }
            CreateDirectorViewModel createDirector = new CreateDirectorViewModel();
            createDirector.DirectorName = director.DirectorName;
            ViewBag.Id = director.Id;
            return View(createDirector);

        }
        [HttpPost]
        public IActionResult Edit(int id, CreateDirectorViewModel createDirector)
        {
            if (ModelState.IsValid)
            {
                if (_directorService.Edit(id, createDirector))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Id = id;
            return View(createDirector);

        }
        public IActionResult Delete(int id)
        {
            _directorService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}