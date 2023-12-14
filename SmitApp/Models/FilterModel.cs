using CommunityToolkit.Mvvm.ComponentModel;

namespace SmitApp.Models;

public class FilterModel : ObservableObject
{
    private string _name;
    private bool _isChecked;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public bool IsChecked
    {
        get => _isChecked;
        set => SetProperty(ref _isChecked, value);
    }
}