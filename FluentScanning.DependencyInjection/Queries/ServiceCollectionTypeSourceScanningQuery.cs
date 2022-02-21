using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FluentScanning.DependencyInjection.Queries
{
    internal class ServiceCollectionTypeSourceScanningQuery : IScanningQuery
    {
        private readonly IServiceCollectionScanningQueryRoot _root;
        private readonly IRegistrationTypeSelector _typeSelector;
        private readonly IServiceLifetimeSelector _lifetimeSelector;

        public ServiceCollectionTypeSourceScanningQuery(
            IRegistrationTypeSelector typeSelector,
            IServiceLifetimeSelector lifetimeSelector)
        {
            _root = typeSelector.Root;
            _typeSelector = typeSelector;
            _lifetimeSelector = lifetimeSelector;
        }

        public IEnumerator<TypeInfo> GetEnumerator()
            => _root.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IScanningQuery WithComponent(IScanningQueryComponent component)
            => new ServiceCollectionScanningQuery(component, this, _root, _typeSelector, _lifetimeSelector);

        public void Accept(IQueryComponentVisitor visitor) { }
    }
}