using SmitApp.Core.Contracts.Repositories;
using SmitApp.Core.Contracts.Services;
using SmitApp.Models;

namespace SmitApp.Core.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public IEnumerable<Movie> GetMovies()
    {
        return _movieRepository.GetMovies();
    }

    public Movie GetMovieDetailsById(int id)
    {
        return _movieRepository.GetMovieDetailsById(id);
    }
}