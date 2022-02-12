using System;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.DependencyInjection.Queries;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public class ServiceLifetimeSelector
    {
        private readonly ServiceCollectionAssemblyScanner _scanner;
        private readonly IEnumerable<TypeInfo> _enumerable;
        private readonly Type _registrationType;

        internal ServiceLifetimeSelector(
            ServiceCollectionAssemblyScanner scanner, IEnumerable<TypeInfo> enumerable, Type registrationType)
        {
            _scanner = scanner;
            _enumerable = enumerable;
            _registrationType = registrationType;
        }

        public IScanningQuery WithLifetimeOf(ServiceLifetime lifetime)
            => new ServiceCollectionTypeSourceScanningQuery(_scanner, _enumerable, _registrationType, lifetime);
    }
}