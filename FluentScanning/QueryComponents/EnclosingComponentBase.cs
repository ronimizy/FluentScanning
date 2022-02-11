using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.QueryComponents
{
    public abstract class EnclosingComponentBase : IScanningQueryComponent
    {
        private readonly IScanningQueryComponent _component;
        private readonly IEnumerable<TypeInfo> _enumerable;

        protected EnclosingComponentBase(IScanningQueryComponent component, IEnumerable<TypeInfo> enumerable)
        {
            _component = component;
            _enumerable = enumerable;
        }

        public IEnumerator<TypeInfo> GetEnumerator()
        {
            var visitor = new QueryComponentVisitor();
            _component.Accept(visitor);

            return visitor.BuildQuery(_enumerable).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public IScanningQueryComponent Wrap(Func<IScanningQueryComponent, IScanningQueryComponent> wrapper)
            => Wrap(wrapper.Invoke(_component), _enumerable);

        public IQueryComponentVisitor Accept(IQueryComponentVisitor visitor)
            => _component.Accept(visitor);

        protected abstract IScanningQueryComponent Wrap(
            IScanningQueryComponent component, IEnumerable<TypeInfo> enumerable);
    }
}