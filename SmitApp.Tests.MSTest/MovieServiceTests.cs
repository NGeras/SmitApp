using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmitApp.Core.Contracts.Repositories;
using SmitApp.Core.Services;
using SmitApp.Models;

namespace SmitApp.Tests.MSTest;

[TestClass]
public class MovieServiceTests
{
    [TestMethod]
    public void GetMovies_ShouldReturnListOfMovies()
    {
        // Arrange
        var mockRepository = new Mock<IMovieRepository>();
        mockRepository.Setup(repo => repo.GetMovies()).Returns(new List<Movie> { new(), new() });

        var movieService = new MovieService(mockRepository.Object);

        // Act
        var result = movieService.GetMovies();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void GetMovieDetailsById_ShouldReturnMovieDetails()
    {
        // Arrange
        var movieId = 1;
        var mockRepository = new Mock<IMovieRepository>();
        mockRepository.Setup(repo => repo.GetMovieDetailsById(movieId))
            .Returns(new Movie { Id = movieId, Title = "Test Movie" });

        var movieService = new MovieService(mockRepository.Object);

        // Act
        var result = movieService.GetMovieDetailsById(movieId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(movieId, result.Id);
        Assert.AreEqual("Test Movie", result.Title);
    }

    [TestMethod]
    public void GetMovieDetailsById_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var invalidMovieId = -1;
        var mockRepository = new Mock<IMovieRepository>();
        mockRepository.Setup(repo => repo.GetMovieDetailsById(invalidMovieId)).Returns((Movie)null);

        var movieService = new MovieService(mockRepository.Object);

        // Act
        var result = movieService.GetMovieDetailsById(invalidMovieId);

        // Assert
        Assert.IsNull(result);
    }
}