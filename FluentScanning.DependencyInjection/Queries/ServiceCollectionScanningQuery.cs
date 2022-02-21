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
        private readonly IServiceCollectionScanningQueryRoot _root;
        private readonly IRegistrationTypeSelector _typeSelector;
        private readonly IServiceLifetimeSelector _lifetimeSelector;


        public ServiceCollectionScanningQuery(
            IScanningQueryComponent component,
            IScanningQuery previousQuery,
            IServiceCollectionScanningQueryRoot root,
            IRegistrationTypeSelector typeSelector,
            IServiceLifetimeSelector lifetimeSelector)
            : base(component, previousQuery, root)
        {
            _root = root;
            _typeSelector = typeSelector;
            _lifetimeSelector = lifetimeSelector;

            root.Scanner.Apply(this);
        }

        protected override IScanningQuery WithComponent(
            IScanningQueryComponent component, IScanningQuery previousQuery, IEnumerable<TypeInfo> enumerable)
        {
            _root.Scanner.Withdraw(this);
            return new ServiceCollectionScanningQuery(
                component, previousQuery, _root, _typeSelector, _lifetimeSelector);
        }

        internal ServiceCollectionScanningQueryResult GetResult()
            => new ServiceCollectionScanningQueryResult(this, _typeSelector, _lifetimeSelector);
    }
}