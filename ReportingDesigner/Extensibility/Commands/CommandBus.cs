using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ReportingDesigner.Extensibility.Events
{
    public class CommandBus : ICommandBus
    {
        private Dictionary<Type, List<Action<object>>> _handlers;
      
        public CommandBus()
        {
            _handlers = new Dictionary<Type, List<Action<object>>>();
        }

        public void AddHandler<T>(Action<T> handler) where T : ICommand
        {
            if (!_handlers.ContainsKey(typeof(T)))
                _handlers.Add(typeof(T), new List<Action<object>>());

            _handlers[typeof(T)].Add(e => handler((T)e));
        }

        public void Post<T>(T e) where T : ICommand
        {
            var eventType = typeof(T);

            foreach (Type handlerType in _handlers.Keys)
                TryPublishForType(handlerType, eventType, e);
        }

        public void RemoveHandler<T>(Action<T> handler) where T : ICommand
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