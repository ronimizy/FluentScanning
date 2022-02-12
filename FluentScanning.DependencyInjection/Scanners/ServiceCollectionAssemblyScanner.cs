using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.DependencyInjection.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public class ServiceCollectionAssemblyScanner : IDisposable
    {
        private readonly IServiceCollection _collection;
        private readonly IReadOnlyCollection<AssemblyProvider> _providers;
        private readonly List<ServiceCollectionScanningQuery> _appliedQueries;
        private readonly object _lock = new object();
        private readonly bool _lockNeeded;

        internal ServiceCollectionAssemblyScanner(
            IServiceCollection collection, IReadOnlyCollection<AssemblyProvider> providers, bool lockNeeded)
        {
            _appliedQueries = new List<ServiceCollectionScanningQuery>();
            _collection = collection;
            _providers = providers;
            _lockNeeded = lockNeeded;
        }

        public void Dispose()
        {
            if (_lockNeeded)
            {
                lock (_lock) DisposeUnlocked();
            }
            else
            {
                DisposeUnlocked();
            }
        }

        public RegistrationTypeSelector EnqueueAdditionOfTypesThat()
            => new RegistrationTypeSelector(this, GetEnumerable());

        internal void Apply(ServiceCollectionScanningQuery applyingQuery)
        {
            if (_lockNeeded)
            {
                lock (_lock) ApplyUnlocked(applyingQuery);
            }
            else
            {
                ApplyUnlocked(applyingQuery);
            }
        }

        internal void Withdraw(ServiceCollectionScanningQuery withdrawingQuery)
        {
            if (_lockNeeded)
            {
                lock (_lock) WithdrawUnlocked(withdrawingQuery);
            }
            else
            {
                WithdrawUnlocked(withdrawingQuery);
            }
        }

        private void DisposeUnlocked()
        {
            var descriptors = _appliedQueries
                .Select(q => q.GetResult())
                .SelectMany(r => r.TypeInfos,
                    (result, info) => new ServiceDescriptor(result.RegistrationType, info, result.ServiceLifetime));

            _collection.Add(descriptors);
            _appliedQueries.Clear();
        }

        private void ApplyUnlocked(ServiceCollectionScanningQuery applyingQuery)
        {
            if (_appliedQueries.Contains(applyingQuery))
                throw new InvalidOperationException("Query is already applied.");

            _appliedQueries.Add(applyingQuery);
        }

        private void WithdrawUnlocked(ServiceCollectionScanningQuery withdrawingQuery)
        {
            _appliedQueries.Remove(withdrawingQuery);
        }

        private IEnumerable<TypeInfo> GetEnumerable()
            => _providers.Select(p => p.Assembly).Distinct().SelectMany(a => a.DefinedTypes);
    }

    public static class ServiceCollectionExtensions
    {
        public static ServiceCollectionAssemblyScanner UseAssemblyScanner(
            this IServiceCollection serviceCollection, params AssemblyProvider[] providers)
            => new ServiceCollectionAssemblyScanner(serviceCollection, providers, false);

        public static ServiceCollectionAssemblyScanner UseAssemblyScannerWithLock(
            this IServiceCollection serviceCollection, params AssemblyProvider[] providers)
            => new ServiceCollectionAssemblyScanner(serviceCollection, providers, true);
    }
}