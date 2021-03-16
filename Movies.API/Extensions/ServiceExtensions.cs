using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Domain.Services;

namespace Movies.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServicesSettings>(configuration.GetSection("ServicesSettings"));
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
