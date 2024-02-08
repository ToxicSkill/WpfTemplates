using System;
using Wpf.Ui;

namespace MvvmFluentDIApp.Interfaces
{
    public interface ICustomPageService : IPageService
    {
        event EventHandler<string> OnPageNavigate;
    }
}