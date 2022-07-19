using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Data;


namespace WebShopMVCMovies.Models.Repos
{
    public class DatabaseLanguageRepo : ILanguageRepo
    {
        private MovieDbContext _movieDbContext;
        public DatabaseLanguageRepo(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Language Create(Language language)
        {
            _movieDbContext.Languages.Add(language);
            if (_movieDbContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;
        }


        public List<Language> GetAll()
        {
            return _movieDbContext.Languages.ToList();
        }

        public Language FindById(int id)
        {
            return _movieDbContext.Languages
                    .SingleOrDefault(language => language.Id == id);
        }

        public bool Update(Language language)
        {
            _movieDbContext.Languages.Update(language);
            if (_movieDbContext.SaveChanges() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Delete(Language language)
        {
            _movieDbContext.Languages.Remove(language);
            if (_movieDbContext.SaveChanges() == 0)
            {
                return false;
            }

            return true;
        }
    }
}