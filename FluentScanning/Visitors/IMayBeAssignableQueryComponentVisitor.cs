using FluentScanning.QueryComponents;

namespace FluentScanning.Visitors
{
    public interface IMayBeAssignableQueryComponentVisitor : IQueryComponentVisitor
    {
        void VisitMayBeAssignableToTypeComponent(MayBeAssignableToTypeComponent component);
    }
}