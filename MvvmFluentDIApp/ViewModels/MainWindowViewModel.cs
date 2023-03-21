using CommunityToolkit.Mvvm.ComponentModel;
using MvvmFluentDIApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;

namespace MvvmFluentDIApp.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public ICollection<INavigationControl> menuItems;

        [ObservableProperty]
        public ICollection<INavigationControl> footerItems;

        public MainWindowViewModel()
        {
            menuItems = new ObservableCollection<INavigationControl>();
            footerItems = new ObservableCollection<INavigationControl>();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            MenuItems.Add(new NavigationItem()
            {
                Icon = SymbolRegular.Home20,
                PageTag = "home",
                Cache = true,
                Content = "Home",
                PageType = typeof(HomeView)
            });
            FooterItems.Add(new NavigationItem()
            {
                Icon = SymbolRegular.Settings20,
                PageTag = "settings",
                Cache = true,
                Content = "Settings",
                PageType = typeof(SettingsView)
            });
        }
    }
}
