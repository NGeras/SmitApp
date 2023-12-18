using SmitApp.Core.Contracts.Repositories;
using SmitApp.Models;

namespace SmitApp.Core.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> movies = new()
    {
        new Movie
        {
            Id = 1, Title = "Movie1", Description = "Description1 for Movie1 that was released in 2003", Year = 2003,
            Rating = 5, CategoryId = 8
        },
        new Movie
        {
            Id = 2, Title = "Movie2", Description = "Description2 for Movie2 that was released in 1964", Year = 1964,
            Rating = 4, CategoryId = 10
        },
        new Movie
        {
            Id = 3, Title = "Movie3", Description = "Description3 for Movie3 that was released in 1955", Year = 1955,
            Rating = 4, CategoryId = 10
        },
        new Movie
        {
            Id = 4, Title = "Movie4", Description = "Description4 for Movie4 that was released in 1993", Year = 1993,
            Rating = 10, CategoryId = 9
        },
        new Movie
        {
            Id = 5, Title = "Movie5", Description = "Description5 for Movie5 that was released in 1956", Year = 1956,
            Rating = 5, CategoryId = 3
        },
        new Movie
        {
            Id = 6, Title = "Movie6", Description = "Description6 for Movie6 that was released in 1995", Year = 1995,
            Rating = 9, CategoryId = 8
        },
        new Movie
        {
            Id = 7, Title = "Movie7", Description = "Description7 for Movie7 that was released in 1952", Year = 1952,
            Rating = 1, CategoryId = 9
        },
        new Movie
        {
            Id = 8, Title = "Movie8", Description = "Description8 for Movie8 that was released in 1992", Year = 1992,
            Rating = 8, CategoryId = 3
        },
        new Movie
        {
            Id = 9, Title = "Movie9", Description = "Description9 for Movie9 that was released in 1959", Year = 1959,
            Rating = 2, CategoryId = 8
        },
        new Movie
        {
            Id = 10, Title = "Movie10", Description = "Description10 for Movie10 that was released in 1997",
            Year = 1997, Rating = 5, CategoryId = 4
        },
        new Movie
        {
            Id = 11, Title = "Movie11", Description = "Description11 for Movie11 that was released in 1981",
            Year = 1981, Rating = 6, CategoryId = 4
        },
        new Movie
        {
            Id = 12, Title = "Movie12", Description = "Description12 for Movie12 that was released in 1976",
            Year = 1976, Rating = 4, CategoryId = 8
        },
        new Movie
        {
            Id = 13, Title = "Movie13", Description = "Description13 for Movie13 that was released in 1991",
            Year = 1991, Rating = 7, CategoryId = 5
        },
        new Movie
        {
            Id = 14, Title = "Movie14", Description = "Description14 for Movie14 that was released in 1952",
            Year = 1952, Rating = 2, CategoryId = 5
        },
        new Movie
        {
            Id = 15, Title = "Movie15", Description = "Description15 for Movie15 that was released in 1957",
            Year = 1957, Rating = 4, CategoryId = 2
        },
        new Movie
        {
            Id = 16, Title = "Movie16", Description = "Description16 for Movie16 that was released in 1958",
            Year = 1958, Rating = 1, CategoryId = 9
        },
        new Movie
        {
            Id = 17, Title = "Movie17", Description = "Description17 for Movie17 that was released in 2018",
            Year = 2018, Rating = 3, CategoryId = 2
        },
        new Movie
        {
            Id = 18, Title = "Movie18", Description = "Description18 for Movie18 that was released in 1988",
            Year = 1988, Rating = 6, CategoryId = 1
        },
        new Movie
        {
            Id = 19, Title = "Movie19", Description = "Description19 for Movie19 that was released in 2013",
            Year = 2013, Rating = 1, CategoryId = 7
        },
        new Movie
        {
            Id = 20, Title = "Movie20", Description = "Description20 for Movie20 that was released in 1991",
            Year = 1991, Rating = 0, CategoryId = 3
        },
        new Movie
        {
            Id = 21, Title = "Movie21", Description = "Description21 for Movie21 that was released in 1965",
            Year = 1965, Rating = 4, CategoryId = 10
        },
        new Movie
        {
            Id = 22, Title = "Movie22", Description = "Description22 for Movie22 that was released in 1995",
            Year = 1995, Rating = 1, CategoryId = 3
        },
        new Movie
        {
            Id = 23, Title = "Movie23", Description = "Description23 for Movie23 that was released in 1986",
            Year = 1986, Rating = 8, CategoryId = 1
        },
        new Movie
        {
            Id = 24, Title = "Movie24", Description = "Description24 for Movie24 that was released in 1986",
            Year = 1986, Rating = 0, CategoryId = 3
        },
        new Movie
        {
            Id = 25, Title = "Movie25", Description = "Description25 for Movie25 that was released in 1974",
            Year = 1974, Rating = 10, CategoryId = 10
        },
        new Movie
        {
            Id = 26, Title = "Movie26", Description = "Description26 for Movie26 that was released in 1982",
            Year = 1982, Rating = 5, CategoryId = 5
        },
        new Movie
        {
            Id = 27, Title = "Movie27", Description = "Description27 for Movie27 that was released in 1953",
            Year = 1953, Rating = 0, CategoryId = 1
        },
        new Movie
        {
            Id = 28, Title = "Movie28", Description = "Description28 for Movie28 that was released in 2013",
            Year = 2013, Rating = 7, CategoryId = 2
        },
        new Movie
        {
            Id = 29, Title = "Movie29", Description = "Description29 for Movie29 that was released in 1962",
            Year = 1962, Rating = 9, CategoryId = 1
        },
        new Movie
        {
            Id = 30, Title = "Movie30", Description = "Description30 for Movie30 that was released in 1969",
            Year = 1969, Rating = 5, CategoryId = 3
        },
        new Movie
        {
            Id = 31, Title = "Movie31", Description = "Description31 for Movie31 that was released in 1956",
            Year = 1956, Rating = 10, CategoryId = 6
        },
        new Movie
        {
            Id = 32, Title = "Movie32", Description = "Description32 for Movie32 that was released in 1964",
            Year = 1964, Rating = 9, CategoryId = 8
        },
        new Movie
        {
            Id = 33, Title = "Movie33", Description = "Description33 for Movie33 that was released in 1987",
            Year = 1987, Rating = 5, CategoryId = 3
        },
        new Movie
        {
            Id = 34, Title = "Movie34", Description = "Description34 for Movie34 that was released in 2013",
            Year = 2013, Rating = 6, CategoryId = 5
        },
        new Movie
        {
            Id = 35, Title = "Movie35", Description = "Description35 for Movie35 that was released in 2007",
            Year = 2007, Rating = 4, CategoryId = 3
        },
        new Movie
        {
            Id = 36, Title = "Movie36", Description = "Description36 for Movie36 that was released in 2020",
            Year = 2020, Rating = 2, CategoryId = 6
        },
        new Movie
        {
            Id = 37, Title = "Movie37", Description = "Description37 for Movie37 that was released in 1961",
            Year = 1961, Rating = 4, CategoryId = 7
        },
        new Movie
        {
            Id = 38, Title = "Movie38", Description = "Description38 for Movie38 that was released in 1966",
            Year = 1966, Rating = 5, CategoryId = 1
        },
        new Movie
        {
            Id = 39, Title = "Movie39", Description = "Description39 for Movie39 that was released in 1961",
            Year = 1961, Rating = 3, CategoryId = 8
        },
        new Movie
        {
            Id = 40, Title = "Movie40", Description = "Description40 for Movie40 that was released in 2007",
            Year = 2007, Rating = 5, CategoryId = 3
        }
    };

    public IEnumerable<Movie> GetMovies()
    {
        return movies;
    }

    public Movie GetMovieDetailsById(int id)
    {
        return movies.FirstOrDefault(movie => movie.Id == id);
    }
}