using SmitApp.Core.Models;
using SmitApp.Models;

namespace SmitApp.Core.Contracts.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetMovies();
    Task<string> GetMovieDetailsById(int id);
}