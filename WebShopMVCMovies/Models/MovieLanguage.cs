using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopMVCMovies.Models
{
    public class MovieLanguage
    {
        public int MovieId { get; set; }
        public Movie movie { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }

    }
}

