﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopMVCMovies.Models
{

         public class Language
        {
            public Language()
            { }
            public Language(string languageName) { LanguageName = languageName; }
            [Key]
            public int Id { get; set; }
            public string LanguageName { get; set; }
            public List<MovieLanguage> MovieLanguages { get; set; } 
        }
    
}
