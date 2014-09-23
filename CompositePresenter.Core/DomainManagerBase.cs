namespace CompositePresenter.Core
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