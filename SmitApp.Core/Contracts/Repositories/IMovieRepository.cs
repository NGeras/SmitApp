﻿using SmitApp.Models;

namespace SmitApp.Core.Contracts.Repositories;

public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
    string GetMovieDetailsById(int id);
}