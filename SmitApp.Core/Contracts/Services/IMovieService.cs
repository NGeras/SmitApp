using SmitApp.Models;

namespace SmitApp.Core.Contracts.Services;

public interface IMovieService
{
    IEnumerable<Movie> GetMovies();
    Movie GetMovieDetailsById(int id);
}