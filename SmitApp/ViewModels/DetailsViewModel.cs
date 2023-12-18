using CommunityToolkit.Mvvm.ComponentModel;
using SmitApp.Contracts.Services;
using SmitApp.Contracts.ViewModels;

namespace SmitApp.ViewModels;

public class DetailsViewModel : ObservableObject, INavigationAware
{
    private readonly IMovieService _moveService;
    private MovieViewModel _selected;

    public DetailsViewModel(IMovieService moveService)
    {
        _moveService = moveService;
    }

    public MovieViewModel Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is not int id) return;
        var movie = await _moveService.GetMovieDetails(id);
        Selected = new MovieViewModel(movie);
    }

    public void OnNavigatedFrom()
    {
    }
}