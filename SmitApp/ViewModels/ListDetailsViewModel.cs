﻿using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmitApp.Contracts.Services;
using SmitApp.Contracts.ViewModels;
using SmitApp.Core.Contracts.Services;
using SmitApp.Core.Models;

namespace SmitApp.ViewModels;

public class ListDetailsViewModel : ObservableObject, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;
    private readonly INavigationService _navigationService;
    private SampleOrder _selected;

    public SampleOrder Selected
    {
        get { return _selected; }
        set
        {
            SetProperty(ref _selected, value);
            if (_selected == null)
            {
                return;
            }
            _navigationService.NavigateTo(typeof(DetailsViewModel).FullName, Selected);
        }
    }

    public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

    public ListDetailsViewModel(ISampleDataService sampleDataService, INavigationService navigationService)
    {
        _sampleDataService = sampleDataService;
        _navigationService = navigationService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        SampleItems.Clear();

        var data = await _sampleDataService.GetListDetailsDataAsync();

        foreach (var item in data)
        {
            SampleItems.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
