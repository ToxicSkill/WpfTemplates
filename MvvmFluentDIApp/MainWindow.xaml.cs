using MvvmFluentDIApp.Interfaces;
using MvvmFluentDIApp.ViewModels;
using MvvmFluentDIApp.Views;
using System;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace MvvmFluentDIApp
{
    public partial class MainWindow : IWindow
    {
        public MainWindowViewModel ViewModel { get; set; }

        public MainWindow(
        MainWindowViewModel viewModel,
        INavigationService navigationService,
        IServiceProvider serviceProvider,
        ISnackbarService snackbarService)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();

            snackbarService.SetSnackbarPresenter(RootSnackbar);
            navigationService.SetNavigationControl(NavigationView);

            NavigationView.SetServiceProvider(serviceProvider);
        }
        private bool _isUserClosedPane;

        private bool _isPaneOpenedOrClosedFromCode;

        private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (sender is not Wpf.Ui.Controls.NavigationView navigationView)
            {
                return;
            }

            NavigationView.HeaderVisibility =
                navigationView.SelectedItem?.TargetPageType != typeof(HomeView)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_isUserClosedPane)
            {
                return;
            }

            _isPaneOpenedOrClosedFromCode = true;
            NavigationView.IsPaneOpen = !(e.NewSize.Width <= 1200);
            _isPaneOpenedOrClosedFromCode = false;
        }

        private void NavigationView_OnPaneOpened(NavigationView sender, RoutedEventArgs args)
        {
            if (_isPaneOpenedOrClosedFromCode)
            {
                return;
            }

            _isUserClosedPane = false;
        }

        private void NavigationView_OnPaneClosed(NavigationView sender, RoutedEventArgs args)
        {
            if (_isPaneOpenedOrClosedFromCode)
            {
                return;
            }

            _isUserClosedPane = true;
        }
    }
}
