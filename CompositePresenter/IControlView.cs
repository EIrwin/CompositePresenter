using System;
using System.Windows.Input;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public interface IControlView:IView
    {
        event EventHandler<MouseButtonEventArgs> MouseDown;
        event EventHandler<MouseEventArgs> MouseMove;
        event EventHandler<MouseEventArgs> MouseUp;

        void SetDescription(string description);
    }
}