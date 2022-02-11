using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.Visitors;

namespace FluentScanning.Query
{
    public abstract class ScanningQueryBase : IScanningQuery
    {
        private readonly IScanningQuery _previousQuery;
        private readonly IScanningQueryComponent _component;
        private readonly IEnumerable<TypeInfo> _enumerable;

        protected ScanningQueryBase(
            IScanningQueryComponent component, IScanningQuery previousQuery, IEnumerable<TypeInfo> enumerable)
        {
            _component = component;
            _enumerable = enumerable;
            _previousQuery = previousQuery;
        }

        public IEnumerator<TypeInfo> GetEnumerator()
        {
            var visitor = new QueryComponentVisitor();
            Accept(visitor);
            return visitor.ApplyQuery(_enumerable).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public IScanningQuery WithComponent(IScanningQueryComponent component)
            => WithComponent(component, this, _enumerable);

        public void Accept(IQueryComponentVisitor visitor)
        {
            _previousQuery.Accept(visitor);
            _component.Accept(visitor);
        }

        protected abstract IScanningQuery WithComponent(
            IScanningQueryComponent component, IScanningQuery previousQuery, IEnumerable<TypeInfo> enumerable);
    }
}