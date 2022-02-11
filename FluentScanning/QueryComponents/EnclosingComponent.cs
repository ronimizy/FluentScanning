using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.QueryComponents
{
    public class EnclosingComponent : EnclosingComponentBase
    {
        public EnclosingComponent(IScanningQueryComponent component, IEnumerable<TypeInfo> enumerable)
            : base(component, enumerable) { }

        protected override IScanningQueryComponent Wrap(IScanningQueryComponent component, IEnumerable<TypeInfo> enumerable)
            => new EnclosingComponent(component, enumerable);
    }
}