using System.Collections.Generic;
using System.Reflection;
using FluentScanning.QueryWrappers;

namespace FluentScanning.DependencyInjection.QueryRegistrationTypeProviders;

internal interface IScanningQueryRegistrationTypeProviderInternal : IScanningQueryRegistrationTypeProvider
{
    IScanningQueryWrapper Wrapper { get; }
    IEnumerable<TypeInfo> Enumerable { get; }
    IRegistrationTypeSelector RegistrationTypeSelector { get; }
}