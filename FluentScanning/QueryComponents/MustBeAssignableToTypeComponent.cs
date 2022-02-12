using System;
using FluentScanning.Visitors;

namespace FluentScanning.QueryComponents
{
    public class MustBeAssignableToTypeComponent : ComponentBase<IMustBeQueryComponentVisitor>
    {
        public MustBeAssignableToTypeComponent(Type type)
        {
            Type = type;
        }

        public Type Type { get; }

        protected override void Accept(IMustBeQueryComponentVisitor visitor)
            => visitor.VisitMustBeAssignableToTypeComponent(this);
    }
}