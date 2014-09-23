using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public sealed class SelectionBoxPresenter:Presenter<ISelectionBoxView>,IDisposable
    {
        private SelectionBoxParameter _parameter;

        public SelectionBoxPresenter(IEventBus eventBus,IParameter parameter) : base(eventBus,parameter)
        {
            _parameter = (SelectionBoxParameter) parameter;

            InitializeView();
        }

        protected override void InitializeView()
        {
            View = new SelectionBox(_parameter.AdornedElement);
            View.Render += OnRender;

            Render();
        }

        private void OnRender(object sender, RenderEventArgs e)
        {
            Draw(e.DrawingContext);
        }

        protected override void Render()
        {
            //The AdornerLayer has already been rendered and initialized
            //so we do not have to subscribe to the 'Loaded' event
            //like we do with adorners that are rendered with its 
            //AdornedElement, we can just grab the AdornerLayer directly
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(_parameter.AdornedElement);
            if (adornerLayer != null) adornerLayer.Add((Adorner) View);
        }

        public override void Dispose()
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual)View);
            if (adornerLayer != null) adornerLayer.Remove((Adorner) View);

            base.Dispose();
        }

        private void Draw(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(_parameter.AdornedElement.DesiredSize);

            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1);

            DrawTopLeft(drawingContext, renderBrush, renderPen, adornedElementRect);
            DrawTopRight(drawingContext, renderBrush, renderPen, adornedElementRect);
            DrawBottomLeft(drawingContext, renderBrush, renderPen, adornedElementRect);
            DrawBottomRight(drawingContext, renderBrush, renderPen, adornedElementRect);
        }

        private void DrawTopLeft(DrawingContext drawingContext, Brush renderBrush, Pen renderPen, Rect adornedElementRect)
        {
            Rect topLeft = new Rect(adornedElementRect.TopLeft.X - 5, adornedElementRect.TopLeft.Y - 10, 5, 5);

            drawingContext.DrawRectangle(renderBrush, renderPen, topLeft);
        }

        private void DrawTopRight(DrawingContext drawingContext, Brush renderBrush, Pen renderPen, Rect adornedElementRect)
        {
            Rect topRight = new Rect(adornedElementRect.TopRight.X, adornedElementRect.TopRight.Y - 10, 5, 5);

            drawingContext.DrawRectangle(renderBrush, renderPen, topRight);
        }

        private void DrawBottomLeft(DrawingContext drawingContext, Brush renderBrush, Pen renderPen, Rect adornedElementRect)
        {
            Rect bottomLeft = new Rect(adornedElementRect.BottomLeft.X - 5, adornedElementRect.BottomLeft.Y + 5, 5, 5);

            drawingContext.DrawRectangle(renderBrush, renderPen, bottomLeft);
        }

        private void DrawBottomRight(DrawingContext drawingContext, Brush renderBrush, Pen renderPen, Rect adornedElementRect)
        {
            Rect bottomRight = new Rect(adornedElementRect.BottomRight.X, adornedElementRect.BottomRight.Y + 5, 5, 5);

            drawingContext.DrawRectangle(renderBrush, renderPen, bottomRight);
        }

    }
}