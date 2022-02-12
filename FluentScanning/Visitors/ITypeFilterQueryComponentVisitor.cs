using FluentScanning.QueryComponents;

namespace FluentScanning.Visitors
{
    public interface ITypeFilterQueryComponentVisitor : IQueryComponentVisitor
    {
        void VisitTypeFilterComponent(TypeFilterComponent component);
    }
}