using System.Windows.Input;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public class ConnectionPointMouseUpEvent : EventBase<MouseButtonEventArgs>
    {
        public ConnectionPointMouseUpEvent(MouseButtonEventArgs eventArgs)
            : base(eventArgs)
        {

        }

        public override MouseButtonEventArgs EventArgs { get; set; }

        public ConnectionPoint Target { get; set; } //temp
    }
}