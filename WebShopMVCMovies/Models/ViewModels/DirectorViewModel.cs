using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopMVCMovies.Models.ViewModels
{
    public class DirectorViewModel
    {
        public List<Director> Directors { get; set; }


        public DirectorViewModel() { Directors = new List<Director>(); }
    }
}

