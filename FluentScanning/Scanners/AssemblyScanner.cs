using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.AssemblyScanningQueryWrappers;
using FluentScanning.Queries;

namespace FluentScanning;

public class AssemblyScanner
{
    private readonly IReadOnlyCollection<AssemblyProvider> _providers;

    public AssemblyScanner(params AssemblyProvider[] providers)
    {
        _providers = providers.ToList();
    }

    public IScanningQuery ScanForTypesThat()
    {
        return new ScanningQuery(GetEnumerable(), new ScanningQueryWrapper());
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