using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FluentScanning.DependencyInjection.Queries
{
    public class ServiceCollectionTypeSourceScanningQuery : IScanningQuery
    {
        private readonly ServiceCollectionAssemblyScanner _scanner;
        private readonly IEnumerable<TypeInfo> _enumerable;
        private readonly Type _registrationType;
        private readonly ServiceLifetime _serviceLifetime;

        public ServiceCollectionTypeSourceScanningQuery(
            ServiceCollectionAssemblyScanner scanner,
            IEnumerable<TypeInfo> enumerable,
            Type registrationType,
            ServiceLifetime serviceLifetime)
        {
            _scanner = scanner;
            _enumerable = enumerable;
            _registrationType = registrationType;
            _serviceLifetime = serviceLifetime;
        }

        public IEnumerator<TypeInfo> GetEnumerator()
            => _enumerable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IScanningQuery WithComponent(IScanningQueryComponent component)
            => new ServiceCollectionScanningQuery(
                _scanner, _enumerable, _registrationType, _serviceLifetime, component, this);

        public void Accept(IQueryComponentVisitor visitor) { }
    }
}