// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.QueryComponents;

namespace FluentScanning
{
    public class QueryComponentVisitor : IQueryComponentVisitor
    {
        private readonly List<Type> _mustBeAssignableTypes = new List<Type>();
        private readonly List<Type> _eitherAssignableTypes = new List<Type>();
        private readonly List<Func<TypeInfo, bool>> _matchers = new List<Func<TypeInfo, bool>>();

        public IEnumerable<TypeInfo> BuildQuery(IEnumerable<TypeInfo> enumerable)
            => enumerable
                .Where(t => _mustBeAssignableTypes.All(tt => tt.IsAssignableFrom(t)))
                .Where(t => _eitherAssignableTypes.Any(tt => tt.IsAssignableFrom(t)))
                .Where(t => _matchers.All(m => m.Invoke(t)));

        public void VisitMustBeAssignableToTypeComponent(MustBeAssignableToTypeComponent component)
            => _mustBeAssignableTypes.Add(component.Type);

        public void VisitEitherAssignableToTypeComponent(EitherAssignableToTypeComponent component)
            => _eitherAssignableTypes.Add(component.Type);

        public void VisitTypeFilterComponent(TypeFilterComponent component)
            => _matchers.Add(component.Match);
    }
}