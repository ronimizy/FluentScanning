using System;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.DependencyInjection.Models;
using FluentScanning.Query;
using Microsoft.Extensions.DependencyInjection;

namespace FluentScanning.DependencyInjection.Queries
{
    internal class ServiceCollectionScanningQuery : ScanningQueryBase
    {
        private readonly ServiceCollectionAssemblyScanner _scanner;
        private readonly Type _registrationType;
        private readonly ServiceLifetime _serviceLifetime;

        internal ServiceCollectionScanningQuery(
            ServiceCollectionAssemblyScanner scanner,
            IEnumerable<TypeInfo> enumerable,
            Type registrationType,
            ServiceLifetime serviceLifetime,
            IScanningQueryComponent component,
            IScanningQuery previousQuery)
            : base(component, previousQuery, enumerable)
        {
            _scanner = scanner;
            _registrationType = registrationType;
            _serviceLifetime = serviceLifetime;
            
            scanner.Apply(this);
        }

        protected override IScanningQuery WithComponent(
            IScanningQueryComponent component, IScanningQuery previousQuery, IEnumerable<TypeInfo> enumerable)
        {
            _scanner.Withdraw(this);
            return new ServiceCollectionScanningQuery(
                _scanner, enumerable, _registrationType, _serviceLifetime, component, previousQuery);
        }

        internal ServiceCollectionScanningQueryResult GetResult()
            => new ServiceCollectionScanningQueryResult(this, _registrationType, _serviceLifetime);
    }
}