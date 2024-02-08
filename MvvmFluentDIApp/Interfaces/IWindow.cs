using System.Windows;

namespace MvvmFluentDIApp.Interfaces
{
    public interface IWindow
    {
        event RoutedEventHandler Loaded;

        void Show();
    }
}
