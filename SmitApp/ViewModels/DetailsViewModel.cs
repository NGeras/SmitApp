using CommunityToolkit.Mvvm.ComponentModel;
using SmitApp.Contracts.ViewModels;
using SmitApp.Core.Models;

namespace SmitApp.ViewModels;

public class DetailsViewModel : ObservableObject, INavigationAware
{
    private SampleOrder _selected;

    public SampleOrder Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter == null) return;
        Selected = parameter as SampleOrder;
    }

    public void OnNavigatedFrom()
    {
    }
}