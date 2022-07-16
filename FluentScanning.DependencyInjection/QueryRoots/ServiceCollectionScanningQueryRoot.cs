using System.Collections.Generic;
using System.Reflection;
using FluentScanning.QueryWrappers;

namespace FluentScanning.DependencyInjection.QueryRoots;

internal class ServiceCollectionScanningQueryRoot : IServiceCollectionScanningQueryRootInternal
{
    public ServiceCollectionScanningQueryRoot(IScanningQueryWrapper wrapper, IEnumerable<TypeInfo> enumerable)
    {
        Wrapper = wrapper;
        Enumerable = enumerable;
    }

    public IScanningQueryWrapper Wrapper { get; }
    public IEnumerable<TypeInfo> Enumerable { get; }
}