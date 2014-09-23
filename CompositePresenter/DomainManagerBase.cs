using CompositePresenter.Core;

namespace CompositePresenter
{
    public abstract class DomainManagerBase:IDomainManager
    {
        protected IEventBus EventBus {get;set;}

        protected DomainManagerBase(IEventBus eventBus)
        {
            EventBus = eventBus;
        }

        internal abstract void AttachHandlers();
    }
}