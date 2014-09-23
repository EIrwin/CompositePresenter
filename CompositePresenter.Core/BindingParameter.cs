using System.Windows;

namespace CompositePresenter.Core
{
    public class BindingParameter
    {
        public Point Point { get; set; }

        public IConnectionPointView ConnectionPoint { get; set; }
    }
}