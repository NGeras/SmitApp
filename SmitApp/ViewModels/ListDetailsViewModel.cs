using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmitApp.Contracts.Services;
using SmitApp.Contracts.ViewModels;
using SmitApp.Core.Contracts.Services;
using SmitApp.Core.Models;
using SmitApp.Models;

namespace SmitApp.ViewModels;

public class ListDetailsViewModel : ObservableObject, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly ISampleDataService _sampleDataService;
    private Action _refreshCollection;
    private string _searchText;
    private SampleOrder _selected;
    private Action<Predicate<object>> _setCollectionFilter;

    public ListDetailsViewModel(ISampleDataService sampleDataService, INavigationService navigationService)
    {
        _sampleDataService = sampleDataService;
        _navigationService = navigationService;
        SetFilterCommand = new RelayCommand(SetFilter);
        RefreshCollectionCommand = new RelayCommand(RefreshCollection);
        FilterList.Add(new FilterModel { Name = "Shipped", IsChecked = false });
        FilterList.Add(new FilterModel { Name = "Closed", IsChecked = false });
    }

    public SampleOrder Selected
    {
        get => _selected;
        set
        {
            SetProperty(ref _selected, value);
            if (_selected == null) return;
            _navigationService.NavigateTo(typeof(DetailsViewModel).FullName, Selected);
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            _refreshCollection.Invoke();
        }
    }

    public ObservableCollection<SampleOrder> SampleItems { get; } = new();
    public ObservableCollection<FilterModel> FilterList { get; } = new();
    public RelayCommand SetFilterCommand { get; }
    public RelayCommand RefreshCollectionCommand { get; }

    public async void OnNavigatedTo(object parameter)
    {
        SampleItems.Clear();
        var data = await _sampleDataService.GetListDetailsDataAsync();
        foreach (var item in data) SampleItems.Add(item);
    }

    public void OnNavigatedFrom()
    {
    }

    private void RefreshCollection()
    {
        _refreshCollection?.Invoke();
    }

    private void SetFilter()
    {
        _setCollectionFilter?.Invoke(MovieFilter);
    }

    private bool MovieFilter(object item)
    {
        if (string.IsNullOrEmpty(SearchText) && !FilterList.Any(x => x.IsChecked))
            return true;

        var movie = (SampleOrder)item;
        var textFilter = string.IsNullOrEmpty(SearchText) ||
                         movie.Company.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
        var categoryFilter = !FilterList.Any(x => x.IsChecked) ||
                             FilterList.Any(filter => filter.IsChecked && movie.Status == filter.Name);

        return textFilter && categoryFilter;
    }

    public void SetupCollectionUpdateLogic(Action<Predicate<object>> listDetailsPageOnLoaded, Action refreshCollection)
    {
        _setCollectionFilter = listDetailsPageOnLoaded;
        _refreshCollection = refreshCollection;
    }
}