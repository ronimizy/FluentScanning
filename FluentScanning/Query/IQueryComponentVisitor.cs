using System.Collections.Generic;
using System.Reflection;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public interface IQueryComponentVisitor
    {
        IEnumerable<TypeInfo> BuildQuery(IEnumerable<TypeInfo> enumerable);

        void VisitMustBeAssignableToTypeComponent(MustBeAssignableToTypeComponent component);
        void VisitEitherAssignableToTypeComponent(EitherAssignableToTypeComponent component);
        void VisitTypeFilterComponent(TypeFilterComponent component);
    }
}