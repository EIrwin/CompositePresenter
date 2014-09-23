using System.Windows;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public class BindingParameter
    {
        public Point Point { get; set; }

        public IConnectionPointView ConnectionPoint { get; set; }
    }
}