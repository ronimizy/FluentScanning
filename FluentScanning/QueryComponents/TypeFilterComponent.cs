using System;
using System.Reflection;
using FluentScanning.Visitors;

namespace FluentScanning.QueryComponents
{
    public class TypeFilterComponent : ComponentBase<ITypeFilterQueryComponentVisitor>
    {
        private readonly Func<TypeInfo, bool> _match;

        public TypeFilterComponent(Func<TypeInfo, bool> match)
        {
            _match = match;
        }

        protected override void Accept(ITypeFilterQueryComponentVisitor visitor)
            => visitor.VisitTypeFilterComponent(this);

        public bool Match(TypeInfo type)
            => _match.Invoke(type);
    }
}