using System.Windows;
using System.Windows.Media;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public interface IConnectionView:IView
    {
        void SetStroke(Brush brush);
        void SetThickness(double thickness);

        void SetStartPoint(Point startPoint);
        void SetEndPoint(Point endPoint);
    }
}