using SmitApp.Core.Contracts.Repositories;
using SmitApp.Models;

namespace SmitApp.Core.Repositories;

public class MovieRepository : IMovieRepository
{
    private List<Movie> movies = new()
    {
        new() { Id = 1, Title = "Movie1", Description = "Description1", Year = 2003, Rating = 5, CategoryId = 8 },
        new() { Id = 2, Title = "Movie2", Description = "Description2", Year = 1964, Rating = 4, CategoryId = 10 },
        new() { Id = 3, Title = "Movie3", Description = "Description3", Year = 1955, Rating = 4, CategoryId = 10 },
        new() { Id = 4, Title = "Movie4", Description = "Description4", Year = 1993, Rating = 10, CategoryId = 9 },
        new() { Id = 5, Title = "Movie5", Description = "Description5", Year = 1956, Rating = 5, CategoryId = 3 },
        new() { Id = 6, Title = "Movie6", Description = "Description6", Year = 1995, Rating = 9, CategoryId = 8 },
        new() { Id = 7, Title = "Movie7", Description = "Description7", Year = 1952, Rating = 1, CategoryId = 9 },
        new() { Id = 8, Title = "Movie8", Description = "Description8", Year = 1992, Rating = 8, CategoryId = 3 },
        new() { Id = 9, Title = "Movie9", Description = "Description9", Year = 1959, Rating = 2, CategoryId = 8 },
        new() { Id = 10, Title = "Movie10", Description = "Description10", Year = 1997, Rating = 5, CategoryId = 4 },
        new() { Id = 11, Title = "Movie11", Description = "Description11", Year = 1981, Rating = 6, CategoryId = 4 },
        new() { Id = 12, Title = "Movie12", Description = "Description12", Year = 1976, Rating = 4, CategoryId = 8 },
        new() { Id = 13, Title = "Movie13", Description = "Description13", Year = 1991, Rating = 7, CategoryId = 5 },
        new() { Id = 14, Title = "Movie14", Description = "Description14", Year = 1952, Rating = 2, CategoryId = 5 },
        new() { Id = 15, Title = "Movie15", Description = "Description15", Year = 1957, Rating = 4, CategoryId = 2 },
        new() { Id = 16, Title = "Movie16", Description = "Description16", Year = 1958, Rating = 1, CategoryId = 9 },
        new() { Id = 17, Title = "Movie17", Description = "Description17", Year = 2018, Rating = 3, CategoryId = 2 },
        new() { Id = 18, Title = "Movie18", Description = "Description18", Year = 1988, Rating = 6, CategoryId = 1 },
        new() { Id = 19, Title = "Movie19", Description = "Description19", Year = 2013, Rating = 1, CategoryId = 7 },
        new() { Id = 20, Title = "Movie20", Description = "Description20", Year = 1991, Rating = 0, CategoryId = 3 },
        new() { Id = 21, Title = "Movie21", Description = "Description21", Year = 1965, Rating = 4, CategoryId = 10 },
        new() { Id = 22, Title = "Movie22", Description = "Description22", Year = 1995, Rating = 1, CategoryId = 3 },
        new() { Id = 23, Title = "Movie23", Description = "Description23", Year = 1986, Rating = 8, CategoryId = 1 },
        new() { Id = 24, Title = "Movie24", Description = "Description24", Year = 1986, Rating = 0, CategoryId = 3 },
        new() { Id = 25, Title = "Movie25", Description = "Description25", Year = 1974, Rating = 10, CategoryId = 10 },
        new() { Id = 26, Title = "Movie26", Description = "Description26", Year = 1982, Rating = 5, CategoryId = 5 },
        new() { Id = 27, Title = "Movie27", Description = "Description27", Year = 1953, Rating = 0, CategoryId = 1 },
        new() { Id = 28, Title = "Movie28", Description = "Description28", Year = 2013, Rating = 7, CategoryId = 2 },
        new() { Id = 29, Title = "Movie29", Description = "Description29", Year = 1962, Rating = 9, CategoryId = 1 },
        new() { Id = 30, Title = "Movie30", Description = "Description30", Year = 1969, Rating = 5, CategoryId = 3 },
        new() { Id = 31, Title = "Movie31", Description = "Description31", Year = 1956, Rating = 10, CategoryId = 6 },
        new() { Id = 32, Title = "Movie32", Description = "Description32", Year = 1964, Rating = 9, CategoryId = 8 },
        new() { Id = 33, Title = "Movie33", Description = "Description33", Year = 1987, Rating = 5, CategoryId = 3 },
        new() { Id = 34, Title = "Movie34", Description = "Description34", Year = 2013, Rating = 6, CategoryId = 5 },
        new() { Id = 35, Title = "Movie35", Description = "Description35", Year = 2007, Rating = 4, CategoryId = 3 },
        new() { Id = 36, Title = "Movie36", Description = "Description36", Year = 2020, Rating = 2, CategoryId = 6 },
        new() { Id = 37, Title = "Movie37", Description = "Description37", Year = 1961, Rating = 4, CategoryId = 7 },
        new() { Id = 38, Title = "Movie38", Description = "Description38", Year = 1966, Rating = 5, CategoryId = 1 },
        new() { Id = 39, Title = "Movie39", Description = "Description39", Year = 1961, Rating = 3, CategoryId = 8 },
        new() { Id = 40, Title = "Movie40", Description = "Description40", Year = 2007, Rating = 5, CategoryId = 3 }
    };

    public IEnumerable<Movie> GetMovies()
    {
        return movies;
    }

    public string GetMovieDetailsById(int id)
    {
        foreach (var movie in movies.Where(movie => movie.Id == id))
        {
            return movie.Description;
        }

        return "No description available";
    }
}