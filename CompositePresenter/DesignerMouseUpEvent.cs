using System.Windows.Input;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public class DesignerMouseUpEvent:EventBase<MouseButtonEventArgs>
    {
        public DesignerMouseUpEvent(MouseButtonEventArgs eventArgs) : base(eventArgs)
        {
        }

        public override MouseButtonEventArgs EventArgs { get; set; }
    }
}