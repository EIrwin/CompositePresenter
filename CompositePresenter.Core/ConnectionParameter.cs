
using System.Windows;
using System.Windows.Controls;

namespace CompositePresenter.Core
{
    public class ConnectionParameter:IParameter
    {
        public Canvas Canvas { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }

        public ConnectionPoint Source { get; set; } //temp
    }
}