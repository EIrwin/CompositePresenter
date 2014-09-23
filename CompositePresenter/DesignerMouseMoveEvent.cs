using System.Windows.Input;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public class DesignerMouseMoveEvent:EventBase<MouseEventArgs>
    {
        public DesignerMouseMoveEvent(MouseEventArgs eventArgs) : base(eventArgs)
        {
        }

        public override MouseEventArgs EventArgs { get; set; }
    }
}