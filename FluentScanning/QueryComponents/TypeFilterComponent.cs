using System;
using System.Reflection;

namespace FluentScanning.QueryComponents
{
    public class TypeFilterComponent : ComponentBase
    {
        private readonly Func<TypeInfo, bool> _match;

        public TypeFilterComponent(IScanningQueryComponent component, Func<TypeInfo, bool> match)
            : base(component)
        {
            _match = match;
        }

        protected override void AcceptLocal(IQueryComponentVisitor visitor)
            => visitor.VisitTypeFilterComponent(this);

        public bool Match(TypeInfo type)
            => _match.Invoke(type);
    }
}