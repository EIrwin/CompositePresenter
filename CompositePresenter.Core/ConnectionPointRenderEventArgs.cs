using System;
using System.Windows.Media;

namespace CompositePresenter.Core
{
    public class RenderEventArgs:EventArgs
    {
        public DrawingContext DrawingContext { get; set; }

        public RenderEventArgs(DrawingContext drawingContext)
        {
            if (drawingContext == null)
                throw new ArgumentNullException("drawingContext");

            DrawingContext = drawingContext;
        }
    }
}