using SmitApp.Core.Models;

namespace SmitApp.Core.Contracts.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetMovies();
    Task<Movie> GetMovieById(int id);

}