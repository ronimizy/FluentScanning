using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.QueryComponents
{
    public abstract class ComponentBase : IScanningQueryComponent
    {
        private readonly IScanningQueryComponent _component;

        protected ComponentBase(IScanningQueryComponent component)
        {
            _component = component;
        }

        public IEnumerator<TypeInfo> GetEnumerator()
            => _component.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public virtual IScanningQueryComponent Wrap(Func<IScanningQueryComponent, IScanningQueryComponent> wrapper)
            => wrapper.Invoke(this);

        public IQueryComponentVisitor Accept(IQueryComponentVisitor visitor)
        {
            AcceptLocal(visitor);
            return _component.Accept(visitor);
        }

        protected abstract void AcceptLocal(IQueryComponentVisitor visitor);
    }
}