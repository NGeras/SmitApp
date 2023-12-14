using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
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
    private SampleOrder _selected;

    public ListDetailsViewModel(ISampleDataService sampleDataService, INavigationService navigationService)
    {
        _sampleDataService = sampleDataService;
        _navigationService = navigationService;
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

    public ObservableCollection<SampleOrder> SampleItems { get; } = new();
    public ObservableCollection<FilterModel> FilterList { get; } = new();

    public async void OnNavigatedTo(object parameter)
    {
        SampleItems.Clear();
        var data = await _sampleDataService.GetListDetailsDataAsync();
        foreach (var item in data) SampleItems.Add(item);
    }

    public void OnNavigatedFrom()
    {
    }
}