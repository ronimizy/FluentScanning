using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.DependencyInjection.ServiceLifetimeSelectors;
using FluentScanning.QueryWrappers;

namespace FluentScanning.DependencyInjection;

internal class ServiceCollectionScanningQuery : IServiceCollectionScanningQueryInternal
{
    private readonly IEnumerable<TypeInfo> _enumerable;

    public ServiceCollectionScanningQuery(
        IEnumerable<TypeInfo> enumerable,
        IScanningQueryWrapper wrapper,
        IRegistrationTypeSelector registrationTypeSelector,
        IServiceLifetimeSelector lifetimeSelector)
    {
        _enumerable = enumerable;
        Wrapper = wrapper;
        RegistrationTypeSelector = registrationTypeSelector;
        LifetimeSelector = lifetimeSelector;
    }

    public IScanningQueryWrapper Wrapper { get; }

    public IRegistrationTypeSelector RegistrationTypeSelector { get; }

    public IServiceLifetimeSelector LifetimeSelector { get; }

    public IEnumerator<TypeInfo> GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}