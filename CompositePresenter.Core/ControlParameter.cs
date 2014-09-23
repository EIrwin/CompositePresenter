
using System.Windows;
using System.Windows.Controls;

namespace CompositePresenter.Core
{
    public class ControlParameter:IParameter
    {
        public Canvas Canvas {get;set;}
        public Point Position { get; set; }
    }
}