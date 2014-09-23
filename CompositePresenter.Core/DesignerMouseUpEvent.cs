using System.Windows.Input;

namespace CompositePresenter.Core
{
    public class DesignerMouseUpEvent:EventBase<MouseButtonEventArgs>
    {
        public DesignerMouseUpEvent(MouseButtonEventArgs eventArgs) : base(eventArgs)
        {
        }

        public override MouseButtonEventArgs EventArgs { get; set; }
    }
}