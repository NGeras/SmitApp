using System.Windows.Controls;

using SmitApp.ViewModels;

namespace SmitApp.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
