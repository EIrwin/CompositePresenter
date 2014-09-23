using System;
using CompositePresenter.Core;

namespace CompositePresenter
{
    public interface ISelectionBoxView:IView
    {
        EventHandler<RenderEventArgs> Render { get; set; }
    }
}