using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmFluentDIApp.ViewModels
{
    public partial class ContentViewModel : ObservableObject
    {
        [ObservableProperty]
        public string welcomeString = "HELLO FROM CONTENT VIEW!";
    }
}
