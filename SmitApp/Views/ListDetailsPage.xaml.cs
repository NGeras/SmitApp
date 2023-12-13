using System.Windows.Controls;

using SmitApp.ViewModels;

namespace SmitApp.Views;

public partial class ListDetailsPage : Page
{
    public ListDetailsPage(ListDetailsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
