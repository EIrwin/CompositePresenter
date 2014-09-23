using System.Windows.Input;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public class DesignerMouseDownEvent:EventBase<MouseButtonEventArgs>
    {
        public DesignerMouseDownEvent(MouseButtonEventArgs eventArgs) : base(eventArgs)
        {

        }

        public override MouseButtonEventArgs EventArgs { get; set; }
    }
}