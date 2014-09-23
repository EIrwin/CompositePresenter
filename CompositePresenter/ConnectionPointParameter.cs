using System.Windows;
using System.Windows.Controls;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public class ConnectionPointParameter:IParameter
    {
        public UIElement AdornedElement { get; set; }
        public ConnectionPointType Type { get; set; }
        public int Index { get; set; }
        public int Count { get; set; }
        public Canvas Canvas { get; set; }
    }
}