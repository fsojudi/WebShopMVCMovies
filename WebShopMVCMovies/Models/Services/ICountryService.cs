using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models.ViewModels;

namespace WebShopMVCMovies.Models.Services
{
    public interface ICountryService
    {
        Country Create(CreateCountryViewModel createCountry);

        List<Country> All();

        List<Country> FindBy(string search);

        Country FindById(int id);

        bool Edit(int id, CreateCountryViewModel editCountry);

        bool Remove(int id);

    }
}