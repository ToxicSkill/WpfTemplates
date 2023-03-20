using MvvmFluentDIApp.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace MvvmFluentDIApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class DashboardView : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel
        {
            get;
        }

        public DashboardView(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
