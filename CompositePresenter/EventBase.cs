using CompositePresenter.Core;

namespace CompositePresenter
{
    public abstract class EventBase<T>:IEvent<T>
    {
        public abstract T EventArgs { get; set; }

        protected EventBase(T eventArgs)
        {
            EventArgs = eventArgs;
        }

    }
}