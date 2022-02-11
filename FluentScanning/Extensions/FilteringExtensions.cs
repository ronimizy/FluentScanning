using System;
using System.Reflection;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public static class FilteringExtensions
    {
        public static IScanningQuery MustBeAssignableTo(this IScanningQuery query, Type type)
            => query.WithComponent(new MustBeAssignableToTypeComponent(type));

        public static IScanningQuery MustBeAssignableTo<T>(this IScanningQuery query)
            => query.MustBeAssignableTo(typeof(T));

        /// <inheritdoc cref="MayBeAssignableToTypeComponent"/>
        public static IScanningQuery MayBeAssignableTo(this IScanningQuery query, Type type)
            => query.WithComponent(new MayBeAssignableToTypeComponent(type));

        /// <inheritdoc cref="MayBeAssignableToTypeComponent"/>
        public static IScanningQuery MayBeAssignableTo<T>(this IScanningQuery query)
            => query.MayBeAssignableTo(typeof(T));

        public static IScanningQuery AreSatisfyingCustomFilter(
            this IScanningQuery query, Func<TypeInfo, bool> predicate)
            => query.WithComponent(new TypeFilterComponent(predicate));

        public static IScanningQuery AreSatisfyingCustomFilter(this IScanningQuery query, ITypeFilter filter)
            => query.AreSatisfyingCustomFilter(filter.Match);

        public static IScanningQuery AreNotInterfaces(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsInterface);

        public static IScanningQuery AreNotAbstractClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsAbstract);

        public static IScanningQuery AreInterfaces(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsInterface);

        public static IScanningQuery AreAbstractClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsAbstract);

        public static IScanningQuery ArePublic(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsPublic);

        public static IScanningQuery AreNotPublic(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsNotPublic);

        public static IScanningQuery AreNotInNamespaceOf(this IScanningQuery query, Type type)
            => query.AreSatisfyingCustomFilter(t => !(t.Namespace?.Equals(type.Namespace) ?? false));

        public static IScanningQuery AreNotInNamespaceOf<T>(this IScanningQuery query)
            => query.AreNotInNamespaceOf(typeof(T));

        public static IScanningQuery AreInNamespaceOf(this IScanningQuery query, Type type)
            => query.AreSatisfyingCustomFilter(t => !(t.Namespace?.Equals(type.Namespace) ?? false));

        public static IScanningQuery AreInNamespaceOf<T>(this IScanningQuery query)
            => query.AreInNamespaceOf(typeof(T));

        public static IScanningQuery AreClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsClass);

        public static IScanningQuery AreNotClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsClass);

        public static IScanningQuery AreValueTypes(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsValueType);

        public static IScanningQuery AreNotValueTypes(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsValueType);
    }
}