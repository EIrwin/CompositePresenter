using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CompositePresenter.Core
{
    public class ConnectionPoint:Adorner,IConnectionPointView
    {
        public ConnectionPoint(UIElement adornedElement) : base(adornedElement)
        {
            this.PreviewMouseLeftButtonDown += ConnectionPoint_PreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonUp += ConnectionPoint_PreviewMouseLeftButtonUp;
            this.PreviewMouseMove += ConnectionPoint_PreviewMouseMove;
        }

        private void ConnectionPoint_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(sender, e);
        }

        private void ConnectionPoint_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseUp(sender, e);
        }

        private void ConnectionPoint_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseDown(sender, e);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Render(this, new RenderEventArgs(drawingContext));
        }

        public Guid Id { get; set; }
        public new EventHandler<MouseButtonEventArgs> MouseDown { get; set; }
        public new EventHandler<MouseButtonEventArgs> MouseUp { get; set; }
        public new EventHandler<MouseEventArgs> MouseMove { get; set; }
        public EventHandler<RenderEventArgs> Render { get; set; }
    }
}