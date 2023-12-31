﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls;
using SmitApp.Contracts.Services;
using SmitApp.Properties;

namespace SmitApp.ViewModels;

public class ShellViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private RelayCommand _goBackCommand;
    private ICommand _loadedCommand;
    private ICommand _menuItemInvokedCommand;
    private ICommand _optionsMenuItemInvokedCommand;
    private HamburgerMenuItem _selectedMenuItem;
    private HamburgerMenuItem _selectedOptionsMenuItem;
    private ICommand _unloadedCommand;

    public ShellViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public HamburgerMenuItem SelectedMenuItem
    {
        get => _selectedMenuItem;
        set => SetProperty(ref _selectedMenuItem, value);
    }

    public HamburgerMenuItem SelectedOptionsMenuItem
    {
        get => _selectedOptionsMenuItem;
        set => SetProperty(ref _selectedOptionsMenuItem, value);
    }

    public ObservableCollection<HamburgerMenuItem> MenuItems { get; } = new()
    {
        new HamburgerMenuGlyphItem
            { Label = Resources.ShellListDetailsPage, Glyph = "\uE8A5", TargetPageType = typeof(ListDetailsViewModel) }
    };

    public ObservableCollection<HamburgerMenuItem> OptionMenuItems { get; } = new()
    {
        new HamburgerMenuGlyphItem
            { Label = Resources.ShellSettingsPage, Glyph = "\uE713", TargetPageType = typeof(SettingsViewModel) }
    };

    public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

    public ICommand MenuItemInvokedCommand =>
        _menuItemInvokedCommand ?? (_menuItemInvokedCommand = new RelayCommand(OnMenuItemInvoked));

    public ICommand OptionsMenuItemInvokedCommand => _optionsMenuItemInvokedCommand ??
                                                     (_optionsMenuItemInvokedCommand =
                                                         new RelayCommand(OnOptionsMenuItemInvoked));

    public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

    public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

    private void OnLoaded()
    {
        _navigationService.Navigated += OnNavigated;
    }

    private void OnUnloaded()
    {
        _navigationService.Navigated -= OnNavigated;
    }

    private bool CanGoBack()
    {
        return _navigationService.CanGoBack;
    }

    private void OnGoBack()
    {
        _navigationService.GoBack();
    }

    private void OnMenuItemInvoked()
    {
        NavigateTo(SelectedMenuItem.TargetPageType);
    }

    private void OnOptionsMenuItemInvoked()
    {
        NavigateTo(SelectedOptionsMenuItem.TargetPageType);
    }

    private void NavigateTo(Type targetViewModel)
    {
        if (targetViewModel != null) _navigationService.NavigateTo(targetViewModel.FullName);
    }

    private void OnNavigated(object sender, string viewModelName)
    {
        var item = MenuItems
            .OfType<HamburgerMenuItem>()
            .FirstOrDefault(i => viewModelName == i.TargetPageType?.FullName);
        if (item != null)
            SelectedMenuItem = item;
        else
            SelectedOptionsMenuItem = OptionMenuItems
                .OfType<HamburgerMenuItem>()
                .FirstOrDefault(i => viewModelName == i.TargetPageType?.FullName);

        GoBackCommand.NotifyCanExecuteChanged();
    }
}