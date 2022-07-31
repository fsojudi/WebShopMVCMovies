using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Models;
using Microsoft.AspNetCore.Identity;

namespace WebShopMVCMovies.Data
{
    public class MovieDbContext : IdentityDbContext<AppUser>
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieLanguage>().HasKey(dtk => new
            {
                dtk.MovieId,
                dtk.LanguageId
            });



            modelBuilder.Entity<MovieLanguage>() // One Movie to Many Languages
                .HasOne(dtk => dtk.Movie)
                .WithMany(dt => dt.MovieLanguages)
                .HasForeignKey(dtk => dtk.MovieId);

            modelBuilder.Entity<MovieLanguage>()  // One Language to Many Movie
                .HasOne(dtk => dtk.Language)
                .WithMany(dt => dt.MovieLanguages)
                .HasForeignKey(dtk => dtk.LanguageId);

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
    }

}
