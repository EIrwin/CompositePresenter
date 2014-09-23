using System.Windows.Input;

namespace CompositePresenter.Core
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