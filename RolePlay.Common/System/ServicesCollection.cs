using System;
using System.Collections.Generic;

namespace RolePlay.Common.System
{
    /// <summary>
    /// Temporary storage of all global project services
    /// </summary>
    public static class ServicesCollection
    {
        private static readonly IDictionary<Type, object> _services;
        static ServicesCollection()
        {
            _services = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Register a new service
        /// </summary>
        /// <typeparam name="T">Type of service</typeparam>
        /// <param name="service">Service for registration</param>
        public static void RegisterService<T>(T service) where T : class
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (_services.ContainsKey(typeof(T)))
            {
                throw new ArgumentException($"Service {typeof(T).FullName} already registered");
            }

            _services.Add(typeof(T), service);
        }

        /// <summary>
        /// Get a service by its type
        /// </summary>
        /// <typeparam name="T">Type of service</typeparam>
        /// <returns>Service of specified type</returns>
        public static T GetService<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out object? service))
            {
                return (T)service;
            }
            else
            {
                throw new ArgumentException($"Service of type {typeof(T).FullName} is not registered");
            }
        }
    }
}
