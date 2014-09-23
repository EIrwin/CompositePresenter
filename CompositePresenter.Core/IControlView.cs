using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CompositePresenter.Core
{
    public interface IControlView:IView
    {
        event EventHandler<MouseButtonEventArgs> MouseDown;
        event EventHandler<MouseEventArgs> MouseMove;
        event EventHandler<MouseEventArgs> MouseUp;

        void SetDescription(string description);
    }
}