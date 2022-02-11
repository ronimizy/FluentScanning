using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.QueryComponents
{
    public abstract class EnclosingComponentBase : IScanningQueryComponent
    {
        private bool _wrapped = false;
        private readonly IScanningQueryComponent _component;

        protected EnclosingComponentBase(IScanningQueryComponent component)
        {
            _component = component;
        }

        public IEnumerator<TypeInfo> GetEnumerator()
        {
            if (_wrapped)
            {
                return _component.GetEnumerator();
            }

            var visitor = new QueryComponentVisitor();
            _component.Accept(visitor);

            var enumerable = ToEnumerable(_component.GetEnumerator());
            return visitor.BuildQuery(enumerable).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public IScanningQueryComponent Wrap(Func<IScanningQueryComponent, IScanningQueryComponent> wrapper)
        {
            _wrapped = true;
            return Wrap(wrapper.Invoke(_component));
        }

        public IQueryComponentVisitor Accept(IQueryComponentVisitor visitor)
            => _component.Accept(visitor);

        protected abstract IScanningQueryComponent Wrap(IScanningQueryComponent component);

        private static IEnumerable<TypeInfo> ToEnumerable(IEnumerator<TypeInfo> enumerator)
        {
            while (enumerator.MoveNext() && enumerator.Current is object)
            {
                yield return enumerator.Current;
            }

            if (enumerator is object)
            {
                enumerator.Dispose();
            }
        }
    }
}