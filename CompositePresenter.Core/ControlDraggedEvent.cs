using System;
using System.Windows;

namespace CompositePresenter.Core
{
    public class ControlDraggedEvent: EventBase<DragEventArgs>
    {
        public ControlDraggedEvent(DragEventArgs eventArgs) : base(eventArgs)
        {
        }

        public override DragEventArgs EventArgs { get; set; }

        public Action<Point> SetPositionCallback { get; set; }

        public Point Position { get; set; }
    }
}