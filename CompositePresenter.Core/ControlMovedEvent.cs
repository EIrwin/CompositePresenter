using System;
using System.Windows;
using System.Windows.Forms;
using DragEventArgs = System.Windows.DragEventArgs;

namespace CompositePresenter.Core
{
    public class ControlMovedEvent:EventBase<System.Windows.Input.MouseEventArgs>
    {
        public ControlMovedEvent(System.Windows.Input.MouseEventArgs eventArgs) : base(eventArgs)
        {

        }

        public override System.Windows.Input.MouseEventArgs EventArgs { get; set; }

        public Action<Point> SetPositionCallback { get; set; }

        public Point Position { get; set; }
    }
}