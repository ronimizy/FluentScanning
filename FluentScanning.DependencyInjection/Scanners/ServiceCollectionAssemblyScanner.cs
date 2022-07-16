using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.DependencyInjection.QueryRoots;
using FluentScanning.DependencyInjection.QueryWrapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FluentScanning.DependencyInjection;

public class ServiceCollectionAssemblyScanner : IDisposable
{
    private readonly List<IServiceCollectionScanningQueryInternal> _appliedQueries;
    private readonly IServiceCollection _collection;
    private readonly object _lock = new object();
    private readonly bool _lockNeeded;
    private readonly IReadOnlyCollection<AssemblyProvider> _providers;

    internal ServiceCollectionAssemblyScanner(
        IServiceCollection collection,
        IReadOnlyCollection<AssemblyProvider> providers,
        bool lockNeeded)
    {
        _appliedQueries = new List<IServiceCollectionScanningQueryInternal>();
        _collection = collection;
        _providers = providers;
        _lockNeeded = lockNeeded;
    }

    public void Dispose()
    {
        if (_lockNeeded)
            lock (_lock)
            {
                DisposeUnlocked();
            }
        else
            DisposeUnlocked();
    }

    public IServiceCollectionScanningQueryRoot EnqueueAdditionOfTypesThat()
    {
        var wrapper = new ServiceCollectionScanningQueryWrapper(this);
        return new ServiceCollectionScanningQueryRoot(wrapper, GetEnumerable());
    }

    internal void Apply(IServiceCollectionScanningQueryInternal applyingQueryOld)
    {
        if (_lockNeeded)
            lock (_lock)
            {
                ApplyUnlocked(applyingQueryOld);
            }
        else
            ApplyUnlocked(applyingQueryOld);
    }

    internal void Withdraw(IServiceCollectionScanningQueryInternal withdrawingQueryOld)
    {
        if (_lockNeeded)
            lock (_lock)
            {
                WithdrawUnlocked(withdrawingQueryOld);
            }
        else
            WithdrawUnlocked(withdrawingQueryOld);
    }

    private void DisposeUnlocked()
    {
        IEnumerable<ServiceDescriptor> descriptors = _appliedQueries
            .SelectMany(r => r, GetServiceDescriptors)
            .SelectMany(x => x);

        _collection.Add(descriptors);
        _appliedQueries.Clear();
    }

    private IEnumerable<ServiceDescriptor> GetServiceDescriptors(
        IServiceCollectionScanningQueryInternal query,
        TypeInfo info)
    {
        IEnumerable<Type> types = query.RegistrationTypeSelector.GetRegistrationTypes(info);
        var lifetime = query.LifetimeSelector.GetLifetime(info);

        return types.Select(t => new ServiceDescriptor(t, info, lifetime));
    }

    private void ApplyUnlocked(IServiceCollectionScanningQueryInternal applyingQueryOld)
    {
        if (_appliedQueries.Contains(applyingQueryOld))
            throw new InvalidOperationException("Query is already applied.");

        _appliedQueries.Add(applyingQueryOld);
    }

    private void WithdrawUnlocked(IServiceCollectionScanningQueryInternal withdrawingQueryOld)
    {
        _appliedQueries.Remove(withdrawingQueryOld);
    }

    private IEnumerable<TypeInfo> GetEnumerable()
    {
        return _providers
            .Select(p => p.Assembly)
            .Distinct()
            .SelectMany(a => a.DefinedTypes)
            .Where(t => t.GetCustomAttribute<AssemblyScanningIgnoreAttribute>() is null);
    }
}

public static class ServiceCollectionExtensions
{
    public static ServiceCollectionAssemblyScanner UseAssemblyScanner(
        this IServiceCollection serviceCollection,
        params AssemblyProvider[] providers)
    {
        return new ServiceCollectionAssemblyScanner(serviceCollection, providers, false);
    }

    public static ServiceCollectionAssemblyScanner UseAssemblyScannerWithLock(
        this IServiceCollection serviceCollection,
        params AssemblyProvider[] providers)
    {
        return new ServiceCollectionAssemblyScanner(serviceCollection, providers, true);
    }
}