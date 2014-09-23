using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CompositePresenter.Core
{
    public sealed class ConnectionPointPresenter:Presenter<IConnectionPointView>
    {
        private ConnectionPointParameter _parameter;

        public ConnectionPointPresenter(IEventBus eventBus, IParameter parameter) : base(eventBus, parameter)
        {
            _parameter = (ConnectionPointParameter) parameter;

            this.InitializeView();
        }

        protected override void InitializeView()
        {
            View = new ConnectionPoint(_parameter.AdornedElement);
            View.MouseDown += OnMouseDown;
            View.MouseUp += OnMouseUp;
            View.MouseMove += OnMouseMove;
            View.Render += OnRender;

            Render();
        }

        protected override void Render()
        {
            //Does the following belong in the Render(...) method?
            ((UserControl) _parameter.AdornedElement).Loaded += (o,e) =>
                {
                    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(_parameter.AdornedElement);
                    adornerLayer.Add((Adorner) View);
                };
        }

        private void OnRender(object sender, RenderEventArgs e)
        {
            RadialGradientBrush renderBrush = new RadialGradientBrush();
            renderBrush.GradientOrigin = new Point(0.75, 0.25);
            renderBrush.GradientStops.Add(new GradientStop(Colors.White, 0.0));
            renderBrush.GradientStops.Add(new GradientStop(Colors.WhiteSmoke, 0.5));
            renderBrush.GradientStops.Add(new GradientStop(Colors.LightGray, 1.0));

            Pen renderPen = new Pen(new SolidColorBrush(Colors.DarkGray), 1);

            double renderRadius = 6.0;

            Point point = GetPosition();

            e.DrawingContext.DrawEllipse(renderBrush, renderPen, point, renderRadius, renderRadius);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Mouse.SetCursor(Cursors.Hand);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            EventBus.PostEvent(new ConnectionPointMouseUpEvent(e)
                {
                    Target = (ConnectionPoint) this.View
                });
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_parameter.Type != ConnectionPointType.Output) return;

            ConnectionParameter parameter = new ConnectionParameter()
                {
                    Canvas = _parameter.Canvas,
                    Start = Mouse.GetPosition(_parameter.Canvas),
                    End = Mouse.GetPosition(_parameter.Canvas),
                    Source = (ConnectionPoint) this.View
                };

            ConnectionPresenter childPresenter = this.AddChild<ConnectionPresenter>(EventBus, parameter);
            childPresenter.Disposed += (presenter, eventArgs) => this.RemoveChild((IPresenter)presenter);
        }

        private Point GetPosition()
        {
            Point point = new Point();

            if (_parameter.Type == ConnectionPointType.Input)
            {
                switch (_parameter.Count)
                {
                    case 1:
                        point = HandleSingleInputAdorner();
                        break;
                    case 2:
                        point = HandleDoubleInputAdorner(_parameter.Index);
                        break;
                    case 3:
                        point = HandleTripleInputAdorner(_parameter.Index);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else if(_parameter.Type == ConnectionPointType.Output)
            {
                switch (_parameter.Count)
                {
                    case 1:
                        point = HandleSingleOutputAdorner();
                        break;
                    case 2:
                        point = HandleDoubleOutputAdorner(_parameter.Index);
                        break;
                    case 3:
                        point = HandleTripleOutputAdorner(_parameter.Index);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return point;
        }

        #region [One Input Methods]

        private Point HandleSingleInputAdorner()
        {
            return GetSingleInputConnectionPoint();
        }

        private Point HandleSingleOutputAdorner()
        {
            return GetSingleOutputConnectionPoint();
        }

        private Point GetSingleInputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);
            Point pt = new Point();

            double difference = adornedElementRect.TopLeft.Y - adornedElementRect.BottomLeft.Y;
            pt.X = adornedElementRect.TopLeft.X;
            pt.Y = adornedElementRect.TopLeft.Y - (difference / 2);

            return pt;

        }

        private Point GetSingleOutputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);
            Point pt = new Point();

            double difference = adornedElementRect.TopRight.Y - adornedElementRect.BottomRight.Y;
            pt.X = adornedElementRect.TopRight.X;
            pt.Y = adornedElementRect.TopRight.Y - (difference / 2);

            return pt;

        }

        #endregion

        #region [Two Input Methods]

        private Point HandleDoubleInputAdorner(int index)
        {
            Point point = default(Point);

            switch (index)
            {
                case 0:
                    point = GetFirstDoubleInputConnectionPoint();
                    break;
                case 1:
                    point = GetSecondDoubleInputConnectionPoint();
                    break;
            }

            return point;
        }

        private Point HandleDoubleOutputAdorner(int index)
        {
            Point point = default(Point);

            switch (index)
            {
                case 0:
                    point = GetFirstDoubleOutputConnectionPoint();
                    break;
                case 1:
                    point = GetSecondDoubleOutputConnectionPoint();
                    break;
            }

            return point;
        }

        private Point GetFirstDoubleInputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopLeft.Y - adornedElementRect.BottomLeft.Y;
            pt.Y = adornedElementRect.TopLeft.Y - (difference / 3);
            pt.X = adornedElementRect.TopLeft.X;
            return pt;
        }

        private Point GetSecondDoubleInputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopLeft.Y - adornedElementRect.BottomLeft.Y;
            pt.Y = adornedElementRect.TopLeft.Y - (difference / 3) * 2;
            pt.X = adornedElementRect.TopLeft.X;
            return pt;
        }

        private Point GetFirstDoubleOutputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopRight.Y - adornedElementRect.BottomRight.Y;
            pt.Y = adornedElementRect.TopRight.Y - (difference / 3);
            pt.X = adornedElementRect.TopRight.X;
            return pt;
        }

        private Point GetSecondDoubleOutputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopRight.Y - adornedElementRect.BottomRight.Y;
            pt.Y = adornedElementRect.TopRight.Y - (difference / 3) * 2;
            pt.X = adornedElementRect.TopRight.X;
            return pt;
        }

        #endregion

        #region [Three Input Methods]

        private Point HandleTripleInputAdorner(int index)
        {
            Point point = default(Point);

            switch (index)
            {
                case 0:
                    point = GetFirstTripleInputConnectionPoint();
                    break;
                case 1:
                    point = GetSecondTripleInputConnectionPoint();
                    break;
                case 2:
                    point = GetThirdTripleInputConnectionPoint();
                    break;
            }

            return point;
        }

        private Point HandleTripleOutputAdorner(int index)
        {
            Point point = default(Point);

            switch (index)
            {
                case 0:
                    point = GetFirstTripleOutputConnectionPoint();
                    break;
                case 1:
                    point = GetSecondTripleOutputConnectionPoint();
                    break;
                case 2:
                    point = GetThirdTripleOutputConnectionPoint();
                    break;
            }

            return point;
        }

        private Point GetFirstTripleInputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopLeft.Y - adornedElementRect.BottomLeft.Y;
            pt.Y = adornedElementRect.TopLeft.Y - (difference / 4);
            pt.X = adornedElementRect.TopLeft.X;
            return pt;
        }

        private Point GetSecondTripleInputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopLeft.Y - adornedElementRect.BottomLeft.Y;
            pt.Y = adornedElementRect.TopLeft.Y - (difference / 4) * 2;
            pt.X = adornedElementRect.TopLeft.X;
            return pt;
        }

        private Point GetThirdTripleInputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopLeft.Y - adornedElementRect.BottomLeft.Y;
            pt.Y = adornedElementRect.TopLeft.Y - (difference / 4) * 3;
            pt.X = adornedElementRect.TopLeft.X;
            return pt;
        }

        private Point GetFirstTripleOutputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopRight.Y - adornedElementRect.BottomRight.Y;
            pt.Y = adornedElementRect.TopRight.Y - (difference / 4);
            pt.X = adornedElementRect.TopRight.X;
            return pt;
        }

        private Point GetSecondTripleOutputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopRight.Y - adornedElementRect.BottomRight.Y;
            pt.Y = adornedElementRect.TopRight.Y - (difference / 4) * 2;
            pt.X = adornedElementRect.TopRight.X;
            return pt;
        }

        private Point GetThirdTripleOutputConnectionPoint()
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            Point pt = new Point();
            double difference = adornedElementRect.TopRight.Y - adornedElementRect.BottomRight.Y;
            pt.Y = adornedElementRect.TopRight.Y - (difference / 4) * 3;
            pt.X = adornedElementRect.TopRight.X;
            return pt;
        }

        #endregion
    }
}