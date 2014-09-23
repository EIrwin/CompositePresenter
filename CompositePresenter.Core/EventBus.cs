using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositePresenter.Core
{
    public class EventBus : IEventBus
    {
        private Dictionary<Type, List<Action<object>>> _handlers;

        public EventBus()
        {
            _handlers = new Dictionary<Type, List<Action<object>>>();
        }

        public void AddHandler<T>(Action<T> handler) 
        {
            if (!_handlers.ContainsKey(typeof(T)))
                _handlers.Add(typeof(T), new List<Action<object>>());

            _handlers[typeof(T)].Add(e => handler((T)e));
        }

        public void PostEvent<T>(T e)
        {
            var eventType = typeof(T);

            foreach (Type handlerType in _handlers.Keys)
                TryPublishForType(handlerType, eventType, e);
        }

        public void RemoveHandler<T>(Action<T> handler)
        {
            //if (_handlers.ContainsKey(typeof (T)))
                //Need to somehow remove handler from list
        }

        private void TryPublishForType(Type handlerType, Type eventType, object e)
        {
            if (handlerType.IsAssignableFrom(eventType))
                _handlers[handlerType].ForEach(handler => handler(e));
        }
    }
}