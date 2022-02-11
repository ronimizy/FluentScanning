using System;

namespace FluentScanning.QueryComponents
{
    public class EitherAssignableToTypeComponent : ComponentBase
    {
        public EitherAssignableToTypeComponent(IScanningQueryComponent component, Type type)
            : base(component)
        {
            Type = type;
        }

        public Type Type { get; }

        protected override void AcceptLocal(IQueryComponentVisitor visitor)
            => visitor.VisitEitherAssignableToTypeComponent(this);
    }
}