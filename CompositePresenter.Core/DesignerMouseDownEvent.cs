using System.Windows.Input;

namespace CompositePresenter.Core
{
    public class DesignerMouseDownEvent:EventBase<MouseButtonEventArgs>
    {
        public DesignerMouseDownEvent(MouseButtonEventArgs eventArgs) : base(eventArgs)
        {

        }

        public override MouseButtonEventArgs EventArgs { get; set; }
    }
}