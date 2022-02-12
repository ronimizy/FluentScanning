using System;
using FluentScanning.Visitors;

namespace FluentScanning.QueryComponents
{
    /// <summary>
    /// A type that are assignable to specified type and to ones that are specified by <see cref="MustBeAssignableToTypeComponent"/>s are allowed.
    /// </summary>
    public class MayBeAssignableToTypeComponent : ComponentBase<IMayBeAssignableQueryComponentVisitor>
    {
        public MayBeAssignableToTypeComponent(Type type)
        {
            Type = type;
        }

        public Type Type { get; }

        protected override void Accept(IMayBeAssignableQueryComponentVisitor visitor)
            => visitor.VisitMayBeAssignableToTypeComponent(this);
    }
}