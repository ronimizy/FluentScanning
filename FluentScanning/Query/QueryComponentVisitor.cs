using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public class QueryComponentVisitor : IQueryComponentVisitor
    {
        private readonly List<Type> _mustBeAssignableTypes = new List<Type>();
        private readonly List<Type> _eitherAssignableTypes = new List<Type>();
        private readonly List<Func<TypeInfo, bool>> _matchers = new List<Func<TypeInfo, bool>>();

        public IEnumerable<TypeInfo> BuildQuery(IEnumerable<TypeInfo> enumerable)
        {
            if (_mustBeAssignableTypes.Any())
            {
                enumerable = enumerable.Where(t => _mustBeAssignableTypes.All(tt => tt.IsAssignableFrom(t)));
            }

            if (_eitherAssignableTypes.Any())
            {
                enumerable = enumerable.Where(t => _eitherAssignableTypes.Any(tt => tt.IsAssignableFrom(t)));
            }

            if (_matchers.Any())
            {
                enumerable = enumerable.Where(t => _matchers.All(m => m.Invoke(t)));
            }

            return enumerable;
        }

        public void VisitMustBeAssignableToTypeComponent(MustBeAssignableToTypeComponent component)
            => _mustBeAssignableTypes.Add(component.Type);

        public void VisitEitherAssignableToTypeComponent(EitherAssignableToTypeComponent component)
            => _eitherAssignableTypes.Add(component.Type);

        public void VisitTypeFilterComponent(TypeFilterComponent component)
            => _matchers.Add(component.Match);
    }
}