using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CompositePresenter.Core
{
    /// <summary>
    /// Interaction logic for Designer.xaml
    /// </summary>
    public partial class Designer : IDesignerView
    {
        public Designer()
        {
            InitializeComponent();
        }

        private void DesignerCanvas_PreviewDrop(object sender, DragEventArgs e)
        {
            ControlDropped(sender, e);
        }

        private void DesignerCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDown(sender, e);
        }

        private void DesignerCanvas_PreviewDragOver(object sender, DragEventArgs e)
        {
            ControlDraggedOver(sender, e);
        }

        private void DesignerCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded(sender, e);
        }

        private void DesignerCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(sender, e);
        }


        public event EventHandler<DragEventArgs> ControlDropped;
        public new event EventHandler<MouseButtonEventArgs> MouseLeftButtonDown;
        public event EventHandler<DragEventArgs> ControlDraggedOver;
        public new event EventHandler<RoutedEventArgs> Loaded;
        public event EventHandler<MouseEventArgs> MouseMove;

        public void SetDimensions(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public void SetCanvas(Canvas canvas)
        {
            this.AddChild(canvas);
        }

        public Guid Id { get; set; }
    }
}
