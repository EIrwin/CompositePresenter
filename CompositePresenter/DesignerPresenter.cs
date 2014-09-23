using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public sealed class DesignerPresenter:Presenter<IDesignerView>
    {
        private DesignerParameter _parameter;

        public DesignerPresenter(IEventBus eventBus,IParameter parameter) : base(eventBus,parameter)
        {
            _parameter = (DesignerParameter) parameter;

            InitializeView();
        }

        protected override void InitializeView()
        {
            //InitializeView View Here
            View = new Designer();
            View.ControlDraggedOver += OnControlDraggedOver;
            View.ControlDropped += OnControlDropped;
            View.MouseLeftButtonDown += OnMouseLeftButtonDown;
            View.Loaded += OnLoaded;

            Render();
        }

        protected override void Render()
        {

            //InitializeView Canvas -> Only temporary...I Think..ask Joe
            //about how this impacts the handlers that are usually on the UI
            //but are now only on this class
            Canvas canvas = ((DesignerParameter)Parameter).Canvas;
            canvas.Background = new SolidColorBrush(Colors.White);
            canvas.AllowDrop = true;
            canvas.PreviewDrop += OnControlDropped;
            canvas.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
            canvas.PreviewDragOver += OnControlDraggedOver;
            canvas.PreviewMouseMove += OnMouseMove;
            canvas.PreviewMouseUp += OnMouseUp;
            canvas.Loaded += OnLoaded;

            View.SetCanvas(_parameter.Canvas);
            View.SetDimensions(350, 425);


        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource is Canvas)) return;  //why do I have to do this?
            
            EventBus.PostEvent(new DesignerMouseUpEvent(e));
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            EventBus.PostEvent(new DesignerMouseMoveEvent(e));
        }

        private void OnControlDraggedOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
        }

        private void OnMouseLeftButtonDown(object sender,MouseButtonEventArgs e)
        {
            //Notify designer controls of MouseDown event
            EventBus.PostEvent(new DesignerMouseDownEvent(e));
        }

        private void OnControlDropped(object sender,DragEventArgs e)
        {
            //Logic here for pulling information from
            //UI so that we can build the control/component

            //the following is only temporary
            if (string.IsNullOrEmpty(e.Data.GetData(DataFormats.Text).ToString()))
                return;
            
            //Notify subscribers of ControlDropped event
            EventBus.PostEvent(new ControlDroppedEvent(e));

            IParameter parameter = new ControlParameter()
                {
                    Canvas = _parameter.Canvas,
                    Position = e.GetPosition(_parameter.Canvas)
                };

            this.AddChild<ControlPresenter>(EventBus, parameter);
        }

        private void OnLoaded(object sender,RoutedEventArgs e)
        {
            
        }
    }
}