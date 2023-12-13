using CommunityToolkit.Mvvm.ComponentModel;
using SmitApp.Contracts.Services;
using SmitApp.Contracts.ViewModels;
using SmitApp.Core.Models;

namespace SmitApp.ViewModels;

public class DetailsViewModel : ObservableObject, INavigationAware
{
    private readonly INavigationService _navigationService;

    public DetailsViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    private SampleOrder _selected;

    public SampleOrder Selected
    {
        get { return _selected; }
        set
        {
            SetProperty(ref _selected, value);
        }
    }
    public void OnNavigatedTo(object parameter)
    {
        if (parameter == null)
        {
            return;
        }
        Selected = parameter as SampleOrder;
    }

    public void OnNavigatedFrom()
    {
    }
}