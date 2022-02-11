using System;

namespace FluentScanning.QueryComponents
{
    public class MustBeAssignableToTypeComponent : ComponentBase
    {
        public MustBeAssignableToTypeComponent(IScanningQueryComponent component, Type type)
            : base(component)
        {
            Type = type;
        }

        public Type Type { get; }

        protected override void AcceptLocal(IQueryComponentVisitor visitor)
            => visitor.VisitMustBeAssignableToTypeComponent(this);
    }
}