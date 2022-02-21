using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.DependencyInjection.Queries
{
    public interface IServiceCollectionScanningQueryRoot : IEnumerable<TypeInfo>
    {
        ServiceCollectionAssemblyScanner Scanner { get; }
    }
}