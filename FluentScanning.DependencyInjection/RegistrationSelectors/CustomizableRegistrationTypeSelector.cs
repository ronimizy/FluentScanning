using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.DependencyInjection.Queries;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    internal class CustomizableRegistrationTypeSelector : IRegistrationTypeSelector
    {
        private readonly Func<TypeInfo, Type> _selector;

        public CustomizableRegistrationTypeSelector(
            IServiceCollectionScanningQueryRoot root, Func<TypeInfo, Type> selector)
        {
            Root = root;
            _selector = selector;
        }

        public IServiceCollectionScanningQueryRoot Root { get; }

        public IEnumerable<Type> GetRegistrationTypes(TypeInfo info)
            => Enumerable.Repeat(_selector.Invoke(info), 1);
    }
}