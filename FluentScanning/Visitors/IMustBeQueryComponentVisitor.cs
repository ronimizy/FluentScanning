using FluentScanning.QueryComponents;

namespace FluentScanning.Visitors
{
    public interface IMustBeQueryComponentVisitor : IQueryComponentVisitor
    {
        void VisitMustBeAssignableToTypeComponent(MustBeAssignableToTypeComponent mustBeAssignableToTypeComponent);
    }
}