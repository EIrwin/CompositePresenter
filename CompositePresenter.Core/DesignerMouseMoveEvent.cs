using System.Windows.Input;

namespace CompositePresenter.Core
{
    public class DesignerMouseMoveEvent:EventBase<MouseEventArgs>
    {
        public DesignerMouseMoveEvent(MouseEventArgs eventArgs) : base(eventArgs)
        {
        }

        public override MouseEventArgs EventArgs { get; set; }
    }
}