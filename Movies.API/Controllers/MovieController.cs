using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Domain.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Movies.Domain.Models;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> _logger;
        public MovieController(IMovieService movieService, ILogger<MovieController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }
        [HttpGet("movie-search-by-title")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse))]
        public async Task<IActionResult> MovieSearchByTitle([Required]string title)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var res = await _movieService.MovieSearchByTitle(title);
                return Ok(res);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "The exception occur at the MovieController MovieSearchByTitle action method");
                return StatusCode(500, new { data = "An error occured while executing your request", code = "99", description = "Failed" });
            }
        }
    }
}
