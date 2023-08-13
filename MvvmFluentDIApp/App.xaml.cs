﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmFluentDIApp.Interfaces;
using MvvmFluentDIApp.Services;
using MvvmFluentDIApp.ViewModels;
using MvvmFluentDIApp.Views;
using System.Windows;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace MvvmFluentDIApp
{
    public partial class App : Application
    {
        private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddHostedService<ApplicationHostService>();
            services.AddSingleton<IThemeService, ThemeService>();
            services.AddSingleton<ICustomPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ISnackbarService, SnackbarService>();

            services.AddScoped<SettingsView>();
            services.AddScoped<SettingsViewModel>();

            services.AddScoped<ContentView>();
            services.AddScoped<ContentViewModel>();

            services.AddScoped<HomeView>();
            services.AddScoped<HomeViewModel>();

            services.AddScoped<INavigationWindow, MainWindow>();
            services.AddScoped<MainWindowViewModel>();
        }).Build();

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
        }
    }
}
