using System;

namespace CompositePresenter.Core
{
    public interface IEventBus
    {
        void AddHandler<TEvent>(Action<TEvent> handler);
        void PostEvent<TEvent>(TEvent tEvent);
        void RemoveHandler<TEvent>(Action<TEvent> handler);
    }
}