using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.AssemblyScanningQueryComponents;
using FluentScanning.DependencyInjection.ServiceLifetimeSelectors;
using FluentScanning.QueryWrappers;

namespace FluentScanning.DependencyInjection;

internal class WrappingServiceCollectionScanningQuery : IServiceCollectionScanningQueryInternal
{
    private readonly IScanningQueryComponent _component;
    private readonly IServiceCollectionScanningQueryInternal _previous;

    public WrappingServiceCollectionScanningQuery(
        IServiceCollectionScanningQueryInternal previous,
        IScanningQueryComponent component)
    {
        _previous = previous;
        _component = component;
    }

    public IEnumerator<TypeInfo> GetEnumerator()
    {
        return _component.Filter(_previous).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IScanningQueryWrapper Wrapper => _previous.Wrapper;
    public IRegistrationTypeSelector RegistrationTypeSelector => _previous.RegistrationTypeSelector;
    public IServiceLifetimeSelector LifetimeSelector => _previous.LifetimeSelector;
}