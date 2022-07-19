using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Data;

namespace WebShopMVCMovies.Models.Repos
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        readonly MovieDbContext _movieDbContext;
        public DatabaseCountryRepo(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public Country Create(Country country)
        {

            _movieDbContext.Countries.Add(country);
            _movieDbContext.SaveChanges();
            return country;
        }

        public List<Country> GetAll()
        {
            List<Country> countryList = _movieDbContext.Countries.ToList();
            return countryList;
        }

        public Country FindById(int id)
        {
            return _movieDbContext.Countries.Find(id);
        }
        public bool Update(Country country)
        {
            _movieDbContext.Countries.Update(country);
            int countryUp = _movieDbContext.SaveChanges();

            if (countryUp > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Country country)
        {
            _movieDbContext.Countries.Remove(country);
            int countryDel = _movieDbContext.SaveChanges();

            if (countryDel > 0)
            {
                return true;
            }
            return false;
        }
    }
}