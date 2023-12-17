using System.Windows.Controls;
using System.Windows.Data;
using SmitApp.ViewModels;

namespace SmitApp.Views;

public partial class ListDetailsPage : Page
{
    public ListDetailsPage(ListDetailsViewModel viewModel)
    {
        InitializeComponent();
        viewModel.SetupCollectionUpdateLogic(SetFilter, RefreshCollection);
        DataContext = viewModel;
    }

    private void RefreshCollection()
    {
        CollectionViewSource.GetDefaultView(MovieListView.ItemsSource).Refresh();
    }

    private void SetFilter(Predicate<object> movieFilter)
    {
        CollectionViewSource.GetDefaultView(MovieListView.ItemsSource).Filter = movieFilter;
    }
}