using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmitApp.Core.Models;
using SmitApp.ViewModels;

namespace SmitApp.Views;

public partial class ListDetailsPage : Page
{
    private readonly ListDetailsViewModel _viewmodel;

    public ListDetailsPage(ListDetailsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = _viewmodel = viewModel;
    }

    private void MovieFilter_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        CollectionViewSource.GetDefaultView(MovieListView.ItemsSource).Refresh();
    }

    private void ListDetailsPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        CollectionViewSource.GetDefaultView(MovieListView.ItemsSource).Filter = MovieFilter;
    }

    private bool MovieFilter(object item)
    {
        if (string.IsNullOrEmpty(MovieSearch.Text) && !_viewmodel.FilterList.Any(x => x.IsChecked))
            return true;

        var movie = (SampleOrder)item;
        var textFilter = string.IsNullOrEmpty(MovieSearch.Text) || movie.Company.Contains(MovieSearch.Text, StringComparison.OrdinalIgnoreCase);
        var categoryFilter = !_viewmodel.FilterList.Any(x => x.IsChecked) || _viewmodel.FilterList.Any(filter => filter.IsChecked && movie.Status == filter.Name);

        return textFilter && categoryFilter;
    }

    private void CheckBox_Click(object sender, RoutedEventArgs e)
    {
        CollectionViewSource.GetDefaultView(MovieListView.ItemsSource).Refresh();
    }
}
