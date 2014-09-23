using System;
using System.Windows.Forms;

namespace CompositePresenter.Core
{
    public class ConfigureMouseDownEvent:EventBase<MouseEventArgs>
    {
        public ConfigureMouseDownEvent(MouseEventArgs eventArgs) : base(eventArgs)
        {

        }

        public override MouseEventArgs EventArgs { get; set; }

        public Action<object, string> Callback;
    }
}