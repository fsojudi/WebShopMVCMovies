using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopMVCMovies.Models.Repos
{
    public interface IDirectorRepo
    {
            Director Create(Director director);
            List<Director> GetAll();
            Director FindById(int id);
            bool Update(Director director);
            bool Delete(Director director);
        }

    }
