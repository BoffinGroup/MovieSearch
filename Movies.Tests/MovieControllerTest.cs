using System;
using Xunit;
using Movies.API.Controllers;
using Movies.Domain.Services;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Movies.Tests
{
    public class MovieControllerTest
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> _logger;
        public MovieControllerTest()
        {
            _movieService = new Mock<IMovieService>().Object;
            _logger = new Mock<ILogger<MovieController>>().Object;
        }
        [Fact]
        public async void MovieSearchByTitle_ReturnType_ToBeAssignableToIActionResult()
        {
            //Arrange
            var _sut = new MovieController(_movieService, _logger);
            string title = "In the line of duty";

            //Act
            var movieSearchResponse = await _sut.MovieSearchByTitle(title);
          

            //Assert
            Assert.IsAssignableFrom<IActionResult>(movieSearchResponse);           

        }

        [Fact]
        public async Task MovieSearchByTitle_InvalidQueryPayLoad_ShouldReturnBadRequest()
        {
            //Arrange
            var _sut = new MovieController(_movieService, _logger);
            string title = "In the line of duty";

            _sut.ModelState.AddModelError("Input", "Required");

            //Act
            var movieSearchResponse = await _sut.MovieSearchByTitle(title) as BadRequestObjectResult;
            

            //Assert
            Assert.Equal(400, movieSearchResponse.StatusCode);
            

        }

        [Fact]
        public async void MovieSearchByTitle_ValidTitleString_ShouldReturnOk()
        {
            //Arrange
            var _sut = new MovieController(_movieService, _logger);
            string title = "In the line of duty";

            //Act
           
            var movieSearchResponse = await _sut.MovieSearchByTitle(title) as OkObjectResult;
            

            //Assert
            Assert.Equal(200, movieSearchResponse.StatusCode);        

        }

    }
}
