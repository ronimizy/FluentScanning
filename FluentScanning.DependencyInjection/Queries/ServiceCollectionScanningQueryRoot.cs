using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.DependencyInjection.Queries
{
    public class ServiceCollectionScanningQueryRoot : IServiceCollectionScanningQueryRoot
    {
        private readonly IEnumerable<TypeInfo> _enumerable;

        public ServiceCollectionScanningQueryRoot(
            ServiceCollectionAssemblyScanner scanner, IEnumerable<TypeInfo> enumerable)
        {
            Scanner = scanner;
            _enumerable = enumerable;
        }

        public ServiceCollectionAssemblyScanner Scanner { get; }

        public IEnumerator<TypeInfo> GetEnumerator() => _enumerable.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_enumerable).GetEnumerator();
    }
}