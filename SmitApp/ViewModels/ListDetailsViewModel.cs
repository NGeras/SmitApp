using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmitApp.Contracts.Services;
using SmitApp.Contracts.ViewModels;
using SmitApp.Models;

namespace SmitApp.ViewModels;

public class ListDetailsViewModel : ObservableObject, INavigationAware
{
    private readonly IMovieService _movieService;
    private readonly INavigationService _navigationService;
    private Action _refreshCollection;
    private string _searchText;
    private MovieViewModel _selected;
    private Action<Predicate<object>> _setCollectionFilter;

    public ListDetailsViewModel(IMovieService movieService, INavigationService navigationService)
    {
        _movieService = movieService;
        _navigationService = navigationService;
        SetFilterCommand = new RelayCommand(SetFilter);
        RefreshCollectionCommand = new RelayCommand(RefreshCollection);
        ClearFiltersCommand = new RelayCommand(ClearFilers, CanExecute);
    }

    public MovieViewModel Selected
    {
        get => _selected;
        set
        {
            SetProperty(ref _selected, value);
            if (_selected == null) return;
            _navigationService.NavigateTo(typeof(DetailsViewModel).FullName, Selected.Id);
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            RefreshCollection();
        }
    }

    public ObservableCollection<MovieViewModel> MovieItems { get; } = new();

    public ObservableCollection<FilterModel> FilterList { get; } = new();
    public RelayCommand SetFilterCommand { get; }
    public RelayCommand RefreshCollectionCommand { get; }
    public RelayCommand ClearFiltersCommand { get; }

    public async void OnNavigatedTo(object parameter)
    {
        MovieItems.Clear();
        FilterList.Clear();

        var movies = await _movieService.GetMovies();

        var enumerable = movies as Movie[] ?? movies.ToArray();
        foreach (var movie in enumerable)
        {
            var movieViewModel = new MovieViewModel(movie);
            MovieItems.Add(movieViewModel);
        }

        var distinctCategories = enumerable
            .GroupBy(x => new { x.CategoryId, x.CategoryName })
            .Select(group => new FilterModel
            {
                Name = group.Key.CategoryName,
                Id = group.Key.CategoryId
            });
        foreach (var filterModel in distinctCategories) FilterList.Add(filterModel);
    }

    public void OnNavigatedFrom()
    {
    }

    private bool CanExecute()
    {
        return FilterList.Any(filter => filter.IsChecked);
    }

    private void ClearFilers()
    {
        foreach (var filter in FilterList) filter.IsChecked = false;
        RefreshCollection();
    }

    private void RefreshCollection()
    {
        _refreshCollection?.Invoke();
        ClearFiltersCommand.NotifyCanExecuteChanged();
    }

    private void SetFilter()
    {
        _setCollectionFilter?.Invoke(MovieFilter);
    }

    private bool MovieFilter(object item)
    {
        if (string.IsNullOrEmpty(SearchText) && !FilterList.Any(x => x.IsChecked))
            return true;

        var movie = (MovieViewModel)item;
        var textFilter = string.IsNullOrEmpty(SearchText) ||
                         movie.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
        var categoryFilter = !FilterList.Any(x => x.IsChecked) ||
                             FilterList.Any(filter => filter.IsChecked && movie.CategoryId == filter.Id);

        return textFilter && categoryFilter;
    }

    public void SetupCollectionUpdateLogic(Action<Predicate<object>> listDetailsPageOnLoaded, Action refreshCollection)
    {
        _setCollectionFilter = listDetailsPageOnLoaded;
        _refreshCollection = refreshCollection;
    }
}