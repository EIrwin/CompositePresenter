using System;
using System.Windows.Input;

namespace CompositePresenter.Core
{
    public interface IConnectionPointView:IView
    {
        EventHandler<MouseButtonEventArgs> MouseDown { get; set; }
        EventHandler<MouseButtonEventArgs> MouseUp { get; set; }
        EventHandler<MouseEventArgs> MouseMove { get; set; }
        EventHandler<RenderEventArgs> Render { get; set; }
    }
}