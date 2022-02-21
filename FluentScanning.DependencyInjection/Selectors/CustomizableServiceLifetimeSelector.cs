using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.DependencyInjection.Queries;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    internal class CustomizableServiceLifetimeSelector : IServiceLifetimeSelector
    {
        private readonly Func<TypeInfo, ServiceLifetime> _selector;

        public CustomizableServiceLifetimeSelector(
            IRegistrationTypeSelector typeSelector,
            Func<TypeInfo, ServiceLifetime> selector)
        {
            Root = typeSelector.Root;
            TypeSelector = typeSelector;
            _selector = selector;
        }

        public IServiceCollectionScanningQueryRoot Root { get; }
        public IRegistrationTypeSelector TypeSelector { get; }

        public ServiceLifetime GetLifetime(TypeInfo info)
            => _selector.Invoke(info);

        public IEnumerator<TypeInfo> GetEnumerator() => Root.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IScanningQuery WithComponent(IScanningQueryComponent component)
            => new ServiceCollectionScanningQuery(component, this, Root, TypeSelector, this);

        public void Accept(IQueryComponentVisitor visitor) { }
    }
}