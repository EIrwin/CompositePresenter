using System;
using System.Windows;
using CompositePresenter.Core;

namespace CompositePresenter
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