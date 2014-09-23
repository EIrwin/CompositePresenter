using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace CompositePresenter
{
    public class SelectionBox : Adorner,ISelectionBoxView
    {
        #region [Constructors]

        public SelectionBox(UIElement adornedElement): base(adornedElement)
        {
            
        }

        #endregion

        protected override void OnRender(DrawingContext drawingContext)
        {
            Render(this, new RenderEventArgs(drawingContext));
        }

        public Guid Id { get; set; }
        public EventHandler<RenderEventArgs> Render { get; set; }
    }
}