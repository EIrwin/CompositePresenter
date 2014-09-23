using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Windows.Point;

namespace CompositePresenter.Core
{
    public sealed class ControlPresenter:Presenter<IControlView>
    {
        private readonly ControlParameter _parameter;
        private SelectionBoxPresenter _selectionBoxPresenter;
        private bool _hasCapture;
        private Point _position;
        private Point _relativePosition;

        public ControlPresenter(IEventBus eventBus) : base(eventBus)
        {
            InitializeView();
        }

        public ControlPresenter(IEventBus eventBus, IParameter parameter) : base(eventBus, parameter)
        {
            _parameter = (ControlParameter) parameter;

            this.InitializeView();

            this.AttachEvents();
        }

        protected override void InitializeView()
        {
            //Normally this would be initialized from some type of 
            //factory or control builder. We will need to accept parameters
            //in the constructor most likely in order to receive the information
            //we need in order to pull the correct control/component/overlay/etc
            //InitializeView View Here
            View = new ControlA();
            View.MouseDown += OnMouseDown;
            View.MouseMove += OnMouseMove;
            View.MouseUp += OnMouseUp;

            Render();
        }

        protected override void Render()
        {
            //Set color, size and metadata
            //We might also need to initialize child presenters
            //here for ConnectionPoint initialization

            ConnectionPointParameter inputParameter = new ConnectionPointParameter()
            {
                AdornedElement = (UIElement)View,
                Type = ConnectionPointType.Input,
                Index = 0, 
                Count = 1,
                Canvas = _parameter.Canvas
            };

            ConnectionPointParameter outputParameter = new ConnectionPointParameter()
                {
                    AdornedElement = (UIElement) View,
                    Type = ConnectionPointType.Output,
                    Index = 0,  
                    Count = 2,
                    Canvas = _parameter.Canvas
                };

            ConnectionPointParameter outputParameter2 = new ConnectionPointParameter()
            {
                AdornedElement = (UIElement)View,
                Type = ConnectionPointType.Output,
                Index = 1,
                Count = 2,
                Canvas = _parameter.Canvas
            };

            this.AddChild<ConnectionPointPresenter>(EventBus, inputParameter);
            this.AddChild<ConnectionPointPresenter>(EventBus, outputParameter);
            this.AddChild<ConnectionPointPresenter>(EventBus, outputParameter2);

            _parameter.Canvas.Children.Add((UIElement)View);

            SetPosition(_parameter.Position);

        }

        protected override void AttachEvents()
        {
            EventBus.AddHandler<DesignerMouseDownEvent>(OnDesignerMouseDown);
        }

        private void OnDesignerMouseDown(DesignerMouseDownEvent obj)
        {
            HideSelectedAdorner();
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Mouse.Capture(null);
            _hasCapture = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!_hasCapture) return;

            double x = e.GetPosition(_parameter.Canvas).X;
            double y = e.GetPosition(_parameter.Canvas).Y;

            _relativePosition.X += x - _position.X;
            _relativePosition.Y += y - _position.Y;

            _position.X = x;
            _position.Y = y;
            
            EventBus.PostEvent(new ControlMovedEvent(e)
                {
                    Position = _relativePosition,
                    SetPositionCallback = SetPosition
                });
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture((IInputElement) sender);
            _hasCapture = true;

            _relativePosition = GetPosition((UIElement) sender);
            _position = e.GetPosition(_parameter.Canvas);

            ShowSelectedAdorner();
        }

        public void OpenOverlay(object obj, string title)
        {

        }

        #region [Private Methods]

        private void SetPosition(Point obj)
        {
            Canvas.SetLeft((UIElement)View, obj.X);
            Canvas.SetTop((UIElement)View, obj.Y);
        }

        private Point GetPosition(UIElement element)
        {
            Point position = new Point()
            {
                X = Canvas.GetLeft(element),
                Y = Canvas.GetTop(element)
            };

            return position;
        }

        private void ShowSelectedAdorner()
        {
            SelectionBoxParameter parameter = new SelectionBoxParameter()
                {
                    AdornedElement = (UIElement)this.View
                };

            _selectionBoxPresenter = AddChild<SelectionBoxPresenter>(EventBus, parameter);

        }

        private void HideSelectedAdorner()
        {
            RemoveChild(_selectionBoxPresenter);

            //Need to ask Joe about this and
            //how we want to dispose/hide presenters
            //and their respective views
            if(_selectionBoxPresenter != null)
                _selectionBoxPresenter.Dispose();
        }

        #endregion
    }
}