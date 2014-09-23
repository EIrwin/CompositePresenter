
using System.Windows;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;

namespace CompositePresenter.Core
{
    public interface IConnectionView:IView
    {
        void SetStroke(Brush brush);
        void SetThickness(double thickness);

        void SetStartPoint(Point startPoint);
        void SetEndPoint(Point endPoint);
    }
}