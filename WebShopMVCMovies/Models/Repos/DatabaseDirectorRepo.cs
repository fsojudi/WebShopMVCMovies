using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Data;



namespace WebShopMVCMovies.Models.Repos
{
    public class DatabaseDirectorRepo : IDirectorRepo
    {
        readonly MovieDbContext _movieDbContext;
        public DatabaseDirectorRepo(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public Director Create(Director director)
        {

            _movieDbContext.Directors.Add(director);
            _movieDbContext.SaveChanges();
            return director;
        }

        public List<Director> GetAll()
        {
            return _movieDbContext.Directors.Include(director => director.Country).ToList();

        }

        public Director FindById(int id)
        {
            return _movieDbContext.Directors.SingleOrDefault(director => director.Id == id);
        }

        public bool Update(Director director)
        {
            _movieDbContext.Directors.Update(director);
            int resultUp = _movieDbContext.SaveChanges();
            if (resultUp == 0)
            {
                return false;
            }
            return true;


        }
        public bool Delete(Director director)
        {
            _movieDbContext.Directors.Remove(director);
            int resultDel = _movieDbContext.SaveChanges();
            if (resultDel == 0)
            {
                return false;
            }
            return true;
        }
    }
}
