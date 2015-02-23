using System;
using System.Collections.Generic;

namespace ReportingDesigner.Extensibility.Container
{
    public static class ServiceLocator
    {
        private static IDictionary<Type, object> _services = new Dictionary<Type, object>();

        public static IDictionary<Type, object> GetServices()
        {
            return _services;
        }

        public static T GetService<T>()
        {
            return (T)_services[typeof (T)];
        }

        public static void SetService<T>(T instance)
        {
            _services[typeof (T)] = instance;
        }
    }
}
