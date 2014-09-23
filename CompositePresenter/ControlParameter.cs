using System.Windows;
using System.Windows.Controls;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public class ControlParameter:IParameter
    {
        public Canvas Canvas {get;set;}
        public Point Position { get; set; }
    }
}