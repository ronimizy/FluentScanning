using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.Query;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public class AssemblyScanner
    {
        private readonly IReadOnlyCollection<AssemblyProvider> _providers;

        public AssemblyScanner(params AssemblyProvider[] providers)
        {
            _providers = providers.ToList();
        }

        public IScanningQuery ScanForTypesThat()
            => new TypeSourceScanningQuery(GetEnumerable());

        private IEnumerable<TypeInfo> GetEnumerable()
            => _providers.Select(p => p.Assembly).Distinct().SelectMany(a => a.DefinedTypes);
    }
}