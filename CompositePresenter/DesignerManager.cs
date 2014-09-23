using CompositePresenter.Core;

namespace CompositePresenter
{
    public sealed class DesignerManager:DomainManagerBase
    {
        public DesignerManager(IEventBus eventBus)
            : base(eventBus)
        {
            this.AttachHandlers();
        }

        public void OnControlDropped(ControlDroppedEvent droppedEvent)
        {
            
        }

        internal override void AttachHandlers()
        {
            EventBus.AddHandler<ControlDroppedEvent>(OnControlDropped);
            EventBus.AddHandler<ControlMouseDownEvent>(OnControlMouseDown);//only temporary since we dont have component manager
            EventBus.AddHandler<ControlMovedEvent>(OnControlMoved);//temp
            EventBus.AddHandler<ControlDraggedEvent>(OnControlDragged);//temp
        }

        private void OnControlDragged(ControlDraggedEvent obj)
        {
            obj.SetPositionCallback(obj.Position);
        }

        private void OnControlMoved(ControlMovedEvent obj)
        {
            obj.SetPositionCallback(obj.Position);
        }

        private void OnControlMouseDown(ControlMouseDownEvent obj)
        {
            obj.SetPositionCallback(obj.Position);   //temp

        }
    }
}