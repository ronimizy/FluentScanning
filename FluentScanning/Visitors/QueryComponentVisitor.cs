using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.QueryComponents;

namespace FluentScanning.Visitors
{
    internal class QueryComponentVisitor :
        IMustBeQueryComponentVisitor,
        IMayBeAssignableQueryComponentVisitor,
        ITypeFilterQueryComponentVisitor
    {
        private readonly List<Type> _mustBeAssignableTypes = new List<Type>();
        private readonly List<Type> _eitherAssignableTypes = new List<Type>();
        private readonly List<Func<TypeInfo, bool>> _matchers = new List<Func<TypeInfo, bool>>();

        public IEnumerable<TypeInfo> ApplyQuery(IEnumerable<TypeInfo> enumerable)
        {
            if (_mustBeAssignableTypes.Any())
            {
                enumerable = enumerable.Where(t => _mustBeAssignableTypes.All(tt => tt.IsAssignableFrom(t)));
            }

            if (_eitherAssignableTypes.Any())
            {
                enumerable = enumerable.Where(t => _eitherAssignableTypes.Any(tt => tt.IsAssignableFrom(t)));
            }

            if (!_mustBeAssignableTypes.Any() && !_eitherAssignableTypes.Any())
            {
                enumerable = Array.Empty<TypeInfo>();
            }
            else if (_matchers.Any())
            {
                enumerable = enumerable.Where(t => _matchers.All(m => m.Invoke(t)));
            }

            return enumerable;
        }

        public void VisitMustBeAssignableToTypeComponent(MustBeAssignableToTypeComponent component)
            => _mustBeAssignableTypes.Add(component.Type);

        public void VisitMayBeAssignableToTypeComponent(MayBeAssignableToTypeComponent component)
            => _eitherAssignableTypes.Add(component.Type);

        public void VisitTypeFilterComponent(TypeFilterComponent component)
            => _matchers.Add(component.Match);
    }
}