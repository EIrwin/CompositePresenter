using System;
using System.Windows.Input;
using CompositePresenter.Core;

namespace CompositePresenter
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