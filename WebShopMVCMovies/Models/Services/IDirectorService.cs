using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models.ViewModels;


namespace WebShopMVCMovies.Models.Services
{
   public interface IDirectorService
    {
        Director Create(CreateDirectorViewModel createDirector);

        List<Director> GetAll();

        List<Director> FindBy(string search);

        Director FindById(int id);

        bool Edit(int id, CreateDirectorViewModel directorViewModel);

        bool Remove(int id);

    }
}


