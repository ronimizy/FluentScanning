using System.Collections.Generic;
using System.Reflection;
using FluentScanning.QueryWrappers;

namespace FluentScanning.DependencyInjection.QueryRegistrationTypeProviders;

internal class ScanningQueryRegistrationTypeProvider : IScanningQueryRegistrationTypeProviderInternal
{
    public ScanningQueryRegistrationTypeProvider(
        IScanningQueryWrapper wrapper,
        IEnumerable<TypeInfo> enumerable,
        IRegistrationTypeSelector registrationTypeSelector)
    {
        Wrapper = wrapper;
        Enumerable = enumerable;
        RegistrationTypeSelector = registrationTypeSelector;
    }

    public IScanningQueryWrapper Wrapper { get; }
    public IEnumerable<TypeInfo> Enumerable { get; }
    public IRegistrationTypeSelector RegistrationTypeSelector { get; }
}