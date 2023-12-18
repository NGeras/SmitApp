using System.Windows.Controls;
using SmitApp.ViewModels;

namespace SmitApp.Views;

/// <summary>
///     Interaction logic for Page1.xaml
/// </summary>
public partial class DetailsPage : Page
{
    public DetailsPage(DetailsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}