using System.Windows.Controls;
using MahApps.Metro.Controls;
using SmitApp.Contracts.Views;
using SmitApp.ViewModels;

namespace SmitApp.Views;

public partial class ShellWindow : MetroWindow, IShellWindow
{
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public Frame GetNavigationFrame()
    {
        return shellFrame;
    }

    public void ShowWindow()
    {
        Show();
    }

    public void CloseWindow()
    {
        Close();
    }
}