using MvvmFluentDIApp.ViewModels;
using Wpf.Ui.Controls;


namespace MvvmFluentDIApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class SettingsView : INavigableView<ViewModels.SettingsViewModel>
    {
        public SettingsViewModel ViewModel { get; set; }


        public SettingsView(SettingsViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
