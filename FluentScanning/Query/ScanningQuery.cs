using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.Query
{
    internal class ScanningQuery : ScanningQueryBase
    {
        internal ScanningQuery(
            IScanningQueryComponent component, IScanningQuery previousQuery, IEnumerable<TypeInfo> enumerable)
            : base(component, previousQuery, enumerable) { }

        protected override IScanningQuery WithComponent(
            IScanningQueryComponent component, IScanningQuery previousQuery, IEnumerable<TypeInfo> enumerable)
            => new ScanningQuery(component, previousQuery, enumerable);
    }
}