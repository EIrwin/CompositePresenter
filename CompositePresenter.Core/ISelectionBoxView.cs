using System;

namespace CompositePresenter.Core
{
    public interface ISelectionBoxView:IView
    {
        EventHandler<RenderEventArgs> Render { get; set; }
    }
}