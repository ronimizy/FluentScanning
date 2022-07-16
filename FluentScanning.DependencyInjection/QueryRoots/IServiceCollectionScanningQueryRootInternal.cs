using System.Collections.Generic;
using System.Reflection;
using FluentScanning.QueryWrappers;

namespace FluentScanning.DependencyInjection.QueryRoots;

internal interface IServiceCollectionScanningQueryRootInternal : IServiceCollectionScanningQueryRoot
{
    IScanningQueryWrapper Wrapper { get; }
    IEnumerable<TypeInfo> Enumerable { get; }
}