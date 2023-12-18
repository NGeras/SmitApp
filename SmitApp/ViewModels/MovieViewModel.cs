using CommunityToolkit.Mvvm.ComponentModel;
using SmitApp.Models;

namespace SmitApp.ViewModels;

public class MovieViewModel : ObservableObject
{
    private readonly Movie movie;

    public MovieViewModel(Movie movie)
    {
        this.movie = movie;
    }

    public int Id
    {
        get => movie.Id;
        private set => SetProperty(movie.Id, value, movie, (u, n) => u.Id = n);
    }

    public string Title
    {
        get => movie.Title;
        set => SetProperty(movie.Title, value, movie, (u, n) => u.Title = n);
    }

    public string Description
    {
        get => movie.Description;
        set => SetProperty(movie.Description, value, movie, (u, n) => u.Description = n);
    }

    public string CategoryName
    {
        get => movie.CategoryName;
        set => SetProperty(movie.CategoryName, value, movie, (u, n) => u.CategoryName = n);
    }

    public int CategoryId
    {
        get => movie.CategoryId;
        set => SetProperty(movie.CategoryId, value, movie, (u, n) => u.CategoryId = n);
    }

    public int Year
    {
        get => movie.Year;
        set => SetProperty(movie.Year, value, movie, (u, n) => u.Year = n);
    }

    public int Rating
    {
        get => movie.Rating;
        set => SetProperty(movie.Rating, value, movie, (u, n) => u.Rating = n);
    }
}