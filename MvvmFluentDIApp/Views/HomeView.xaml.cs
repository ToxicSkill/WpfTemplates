using MvvmFluentDIApp.ViewModels;
using Wpf.Ui.Controls;

namespace MvvmFluentDIApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class HomeView : INavigableView<ViewModels.HomeViewModel>
    {
        public HomeViewModel ViewModel { get; set; }

        public HomeView(HomeViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = ViewModel;
        }

    }
}
