using System;
using System.Windows.Input;
using CompositePresenter.Core;

namespace CompositePresenter
{
    /// <summary>
    /// Interaction logic for ControlA.xaml
    /// </summary>
    public partial class ControlA : IControlView
    {
        public ControlA()
        {
            InitializeComponent();
        }

        private void ControlA_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseDown(sender, e);
        }

        private void ControlA_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(sender, e);
        }

        private void ControlA_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseUp(sender, e);
        }

       
        public Guid Id { get; set; }
        public new event EventHandler<MouseButtonEventArgs> MouseDown;
        public new event EventHandler<MouseEventArgs> MouseMove;
        public new event EventHandler<MouseEventArgs> MouseUp;

        public void SetDescription(string description)
        {
            Description.Text = description;
        }
    }
}
