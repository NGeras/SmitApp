using CommunityToolkit.Mvvm.ComponentModel;

namespace SmitApp.Models;

public class FilterModel : ObservableObject
{
    private int _id;
    private bool _isChecked;
    private string _name;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public bool IsChecked
    {
        get => _isChecked;
        set => SetProperty(ref _isChecked, value);
    }
}