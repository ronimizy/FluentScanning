using System;
using System.Collections.Generic;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public class RegistrationTypeSelector
    {
        private readonly ServiceCollectionAssemblyScanner _scanner;
        private readonly IEnumerable<TypeInfo> _enumerable;

        internal RegistrationTypeSelector(ServiceCollectionAssemblyScanner scanner, IEnumerable<TypeInfo> enumerable)
        {
            _scanner = scanner;
            _enumerable = enumerable;
        }

        public ServiceLifetimeSelector AreRegisteredAs(Type type)
            => new ServiceLifetimeSelector(_scanner, _enumerable, type);

        public ServiceLifetimeSelector AreRegisteredAs<T>()
            => AreRegisteredAs(typeof(T));
    }
}