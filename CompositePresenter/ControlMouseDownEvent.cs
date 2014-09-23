using System;
using System.Windows;
using System.Windows.Input;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public class ControlMouseDownEvent:EventBase<MouseButtonEventArgs>
    {
        public ControlMouseDownEvent(MouseButtonEventArgs eventArgs) : base(eventArgs)
        {
            SetPositionCallback = (p) =>
                {
                    //We dont want this to be called
                    //if it is not initialized. We 
                    //can avoid this by iniitalizing 
                    //it with an empt Action delegate
                };
        }

        public override MouseButtonEventArgs EventArgs { get; set; }

        public Point Position { get; set; } //temp
        public Action<Point> SetPositionCallback { get; set; }  //temp

    }
}