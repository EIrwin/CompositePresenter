using System;

namespace CompositePresenter.Core
{
    public class ControlDroppedEvent:EventBase<EventArgs>
    {
        public ControlDroppedEvent(EventArgs eventArgs) : base(eventArgs)
        {

        }

        public override EventArgs EventArgs { get; set; }
    }
}