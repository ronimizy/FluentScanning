using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.Query
{
    internal class TypeSourceScanningQuery : IScanningQuery
    {
        private readonly IEnumerable<TypeInfo> _enumerable;

        internal TypeSourceScanningQuery(IEnumerable<TypeInfo> enumerable)
        {
            _enumerable = enumerable;
        }

        public IEnumerator<TypeInfo> GetEnumerator()
            => _enumerable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public IScanningQuery WithComponent(IScanningQueryComponent component)
            => new ScanningQuery(component, this, _enumerable);

        public void Accept(IQueryComponentVisitor visitor) { }
    }
}