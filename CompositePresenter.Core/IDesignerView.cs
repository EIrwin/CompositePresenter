using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CompositePresenter.Core
{
    public interface IDesignerView:IView
    {
        event EventHandler<DragEventArgs> ControlDropped;
        event EventHandler<MouseButtonEventArgs> MouseLeftButtonDown;
        event EventHandler<DragEventArgs> ControlDraggedOver;
        event EventHandler<RoutedEventArgs> Loaded;
        event EventHandler<MouseEventArgs> MouseMove;

        void SetDimensions(double height, double width);
        void SetCanvas(Canvas canvas);
    }
}