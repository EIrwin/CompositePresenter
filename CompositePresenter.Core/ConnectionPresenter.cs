using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace CompositePresenter.Core
{
    public sealed class ConnectionPresenter:Presenter<IConnectionView>
    {
        private readonly ConnectionParameter _parameter;
        private bool _hasConnection;

        public ConnectionPresenter(IEventBus eventBus,IParameter parameter) : base(eventBus,parameter)
        { 
            _parameter = (ConnectionParameter) parameter;

            this.InitializeView();

            this.AttachEvents();
        }

        protected override void InitializeView()
        {
            View = new Connection();

            Render();
        }

        protected override void AttachEvents()
        {
            EventBus.AddHandler<DesignerMouseMoveEvent>(OnDesignerMouseMove);
            EventBus.AddHandler<DesignerMouseUpEvent>(OnDesignerMouseUp);
            EventBus.AddHandler<ConnectionPointMouseUpEvent>(OnConnectionPointMouseUp);
        }

        public override void Dispose()
        {
            //The following is not properly removing the event handlers - CHECK THIS OUT
            EventBus.RemoveHandler<DesignerMouseMoveEvent>(OnDesignerMouseMove);
            EventBus.RemoveHandler<DesignerMouseUpEvent>(OnDesignerMouseUp);
            EventBus.RemoveHandler<ConnectionPointMouseUpEvent>(OnConnectionPointMouseUp);

            OnDisposed();
        }

        private void OnConnectionPointMouseUp(ConnectionPointMouseUpEvent obj)
        {
            _hasConnection = false;

            //The following doesn't seem to be working
            ((Connection)this.View).SetBinding(Connection.StartPointProperty, CreateCenteredBinding(_parameter.Source));
            ((Connection)this.View).SetBinding(Connection.EndPointProperty, CreateCenteredBinding(obj.Target));
        }

        private void OnDesignerMouseUp(DesignerMouseUpEvent obj)
        {
            //The mouse was released on the designer surface
            //thus we want to make sure that we no longer
            //have reference to a connection
            _hasConnection = false;

            _parameter.Canvas.Children.Remove((UIElement) this.View);

            this.Dispose();
        }

        private void OnDesignerMouseMove(DesignerMouseMoveEvent obj)
        {
            //If we have reference to the connection, then
            //we can update the EndPoint property
            if (_hasConnection)
                ((Connection) this.View).EndPoint = Mouse.GetPosition(_parameter.Canvas);
        }

        protected override void Render()
        {
            View.SetStartPoint(_parameter.Start);
            View.SetEndPoint(_parameter.End);

            View.SetStroke(Brushes.Black);
            View.SetThickness(2);

            _parameter.Canvas.Children.Add((UIElement) View);

            _hasConnection = true;
        }

        public MultiBinding CreateCenteredBinding(IConnectionPointView connectionPoint)
        {
            BindingParameter converterParameter = new BindingParameter()
            {
                Point = new Point(
                    ((FrameworkElement)connectionPoint).ActualWidth / 2,
                    ((FrameworkElement)connectionPoint).ActualHeight / 2),
                ConnectionPoint = connectionPoint
            };

            MultiBinding multiBinding = new MultiBinding();
            multiBinding.Converter = new DefaultCenterBinding();
            multiBinding.ConverterParameter = converterParameter;

            Binding binding = new Binding();
            binding.Source = connectionPoint;
            binding.Path = new PropertyPath(Canvas.LeftProperty);
            multiBinding.Bindings.Add(binding);
            binding.ConverterParameter = connectionPoint;

            binding = new Binding();
            binding.Source = connectionPoint;
            binding.Path = new PropertyPath(Canvas.TopProperty);
            multiBinding.Bindings.Add(binding);
            binding.ConverterParameter = connectionPoint;

            return multiBinding;
        }
    }


}