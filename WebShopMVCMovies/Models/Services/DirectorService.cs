using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models.Repos;
using WebShopMVCMovies.Models.ViewModels;

namespace WebShopMVCMovies.Models.Services
{
    public class DirectorService: IDirectorService
    {

            private readonly IDirectorRepo _directorRepo;

            public DirectorService(IDirectorRepo directorRepo)
            {
            _directorRepo = directorRepo;
            }
            public Director Create(CreateDirectorViewModel createDirector)
            {
                if (string.IsNullOrWhiteSpace(createDirector.DirectorName))
                {
                    return null;
                }

            Director director = new Director()
                {
                DirectorName = createDirector.DirectorName,
                    CountryId = createDirector.CountryId
                };
                return _directorRepo.Create(director);
            }


            public List<Director> GetAll()
            {
                return _directorRepo.GetAll();
            }

            public List<Director> FindBy(string search)
            {
                List<Director> searchDirector = _directorRepo.GetAll();
                //
                foreach (Director item in _directorRepo.GetAll())
                {
                    if (item.DirectorName.Contains(search, StringComparison.OrdinalIgnoreCase))
                    {
                    searchDirector.Add(item);
                    }
                }
                if (searchDirector.Count == 0)
                {
                    throw new ArgumentException("Could not find what you where looking for");
                }
                return searchDirector;
            }

            public Director FindById(int Id)
            {
            Director directorFound = _directorRepo.FindById(Id);
                return directorFound;
            }
            public bool Edit(int Id, CreateDirectorViewModel editDirector)
            {
            Director orginalCountry = FindById(Id);
                if (orginalCountry == null)
                {
                    return false;
                }
                orginalCountry.DirectorName = editDirector.DirectorName;
                return _directorRepo.Update(orginalCountry);
            }
            public bool Remove(int Id)
            {
            Director directorToDelete = _directorRepo.FindById(Id);
                bool succses = _directorRepo.Delete(directorToDelete);
                return succses;
            }
        }
}


