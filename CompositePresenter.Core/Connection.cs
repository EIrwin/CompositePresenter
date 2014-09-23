using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CompositePresenter.Core
{
    public class Connection:Shape,IConnectionView
    {
        public Guid Id { get; set; }
        public static readonly DependencyProperty StartPointProperty = DependencyProperty.Register("StartPoint", typeof(Point), typeof(Connection), new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty EndPointProperty = DependencyProperty.Register("EndPoint", typeof(Point), typeof(Connection), new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.AffectsMeasure));
        public Point StartPoint
        {
            get { return (Point)GetValue(StartPointProperty); }
            set { SetValue(StartPointProperty, value); }
        }
        public Point EndPoint
        {
            get { return (Point)GetValue(EndPointProperty); }
            set { SetValue(EndPointProperty, value); }
        }


        private readonly LineGeometry _lineGeometry;
        protected override Geometry DefiningGeometry
        {
            get
            {
                _lineGeometry.StartPoint = StartPoint;
                _lineGeometry.EndPoint = EndPoint;
                return _lineGeometry;
            }
        }

        public Connection()
        {
            _lineGeometry = new LineGeometry();

            Id = Guid.NewGuid();
        }

        public void SetStroke(Brush brush)
        {
            this.Stroke = brush;
        }

        public void SetThickness(double thickness)
        {
            this.StrokeThickness = thickness;
        }

        public void SetStartPoint(Point startPoint)
        {
            this.StartPoint = startPoint;
        }

        public void SetEndPoint(Point endPoint)
        {
            this.EndPoint = endPoint;
        }
    }
}