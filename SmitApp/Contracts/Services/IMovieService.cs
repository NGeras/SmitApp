using SmitApp.Models;

namespace SmitApp.Contracts.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetMovies();
    Task<Movie> GetMovieDetails(int id);
}