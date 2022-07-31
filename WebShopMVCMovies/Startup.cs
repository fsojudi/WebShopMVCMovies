using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopMVCMovies.Data;
using WebShopMVCMovies.Models.Repos;
using WebShopMVCMovies.Models.Services;
using WebShopMVCMovies.Models;
using Microsoft.OpenApi.Models;

namespace WebShopMVCMovies
{
    public class Startup
    {// Step 4
        public Startup(IConfiguration configuration)
        {// jason appsetting
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {// Step 5
            services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 2;

            });

            // Step 6
            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
            services.AddScoped<IMovieRepo, DatabaseMovieRepo>();// IoC & DI
            services.AddScoped<IMovieService, MovieService>();// IoC & DI

            services.AddScoped<IDirectorRepo, DatabaseDirectorRepo>();// IoC & DI
            services.AddScoped<IDirectorService, DirectorService>();// IoC & DI

            services.AddScoped<ICountryRepo, DatabaseCountryRepo>();// IoC & DI
            services.AddScoped<ICountryService, CountryService>();// IoC & DI

            services.AddScoped<ILanguageRepo, DatabaseLanguageRepo>();// IoC & DI
            services.AddScoped<ILanguageService, LanguageService>();// IoC & DI


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Director API",
                    Version = "v1"
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("*");// replace "*" with the domain or adress from were you will make request from "http://www.my-domain.com"
                                  });
            });

            services.AddMvc().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); // for the static files like jsvascript css and more

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(option => { option.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieAPI"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}