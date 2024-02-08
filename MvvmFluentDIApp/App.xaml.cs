using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmFluentDIApp.Interfaces;
using MvvmFluentDIApp.Services;
using MvvmFluentDIApp.ViewModels;
using MvvmFluentDIApp.Views;
using System.Windows;
using Wpf.Ui;

namespace MvvmFluentDIApp
{
    public partial class App : Application
    {
        private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddHostedService<ApplicationHostService>();
            services.AddSingleton<IWindow, MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ISnackbarService, SnackbarService>();
            services.AddSingleton<WindowsProviderService>();

            services.AddScoped<SettingsView>();
            services.AddScoped<SettingsViewModel>();

            services.AddScoped<ContentView>();
            services.AddScoped<ContentViewModel>();

            services.AddScoped<HomeView>();
            services.AddScoped<HomeViewModel>();

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
