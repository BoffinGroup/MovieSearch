using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Services
{
    public class MovieService: IMovieService
    {
        private readonly ServicesSettings _servicesSettings;
        public MovieService(IOptions<ServicesSettings> servicesSettings)
        {
            _servicesSettings = servicesSettings.Value;
        }
        public async Task<BaseResponse> MovieSearchByTitle(string title)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                string movieUrl = _servicesSettings.MovieURl;
                string apiKey = _servicesSettings.Apikey;
                var res = await movieUrl
                                .SetQueryParams(new { t = title, apikey = apiKey })
                                .GetJsonAsync<Movie>();

                if (res != null)
                {
                    response = new BaseResponse { code = "00", description = "Success", data = res };
                }
                else
                {
                    response = new BaseResponse { code = "99", description = $"No record found with title : {title}", data = null };
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
