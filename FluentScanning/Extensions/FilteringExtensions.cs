using System;
using System.Reflection;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public static class FilteringExtensions
    {
        public static IScanningQueryComponent MustBeAssignableTo(
            this IScanningQueryComponent element, Type type)
            => element.Wrap(e => new MustBeAssignableToTypeComponent(e, type));

        public static IScanningQueryComponent MustBeAssignableTo<T>(
            this IScanningQueryComponent element)
            => element.MustBeAssignableTo(typeof(T));

        public static IScanningQueryComponent EitherAssignableTo(
            this IScanningQueryComponent element, Type type)
            => element.Wrap(e => new EitherAssignableToTypeComponent(e, type));

        public static IScanningQueryComponent EitherAssignableTo<T>(
            this IScanningQueryComponent element)
            => element.EitherAssignableTo(typeof(T));

        public static IScanningQueryComponent WithCustomFilter(
            this IScanningQueryComponent element, Func<TypeInfo, bool> predicate) =>
            element.Wrap(e => new TypeFilterComponent(e, predicate));

        public static IScanningQueryComponent WithCustomFilter(
            this IScanningQueryComponent element, ITypeFilter filter)
            => element.WithCustomFilter(filter.Match);

        public static IScanningQueryComponent ExcludeInterfaces(
            this IScanningQueryComponent element)
            => element.WithCustomFilter(t => !t.IsInterface);

        public static IScanningQueryComponent ExcludeAbstractClasses(
            this IScanningQueryComponent element)
            => element.WithCustomFilter(t => !t.IsAbstract);

        public static IScanningQueryComponent IncludeOnlyInterfaces(
            this IScanningQueryComponent element)
            => element.WithCustomFilter(t => t.IsInterface);

        public static IScanningQueryComponent IncludeOnlyAbstractClasses(
            this IScanningQueryComponent element)
            => element.WithCustomFilter(t => t.IsAbstract);

        public static IScanningQueryComponent ExcludePublic(
            this IScanningQueryComponent element)
            => element.WithCustomFilter(t => !t.IsPublic);

        public static IScanningQueryComponent ExcludeNotPublic(
            this IScanningQueryComponent element)
            => element.WithCustomFilter(t => !t.IsNotPublic);

        public static IScanningQueryComponent IncludeOnlyPublic(
            this IScanningQueryComponent element)
            => element.WithCustomFilter(t => t.IsPublic);

        public static IScanningQueryComponent IncludeOnlyNotPublic(
            this IScanningQueryComponent element)
            => element.WithCustomFilter(t => t.IsNotPublic);

        public static IScanningQueryComponent ExcludeTypesFromNamespaceOf(
            this IScanningQueryComponent element, Type type)
            => element.WithCustomFilter(t => !(t.Namespace?.Equals(type.Namespace) ?? false));

        public static IScanningQueryComponent ExcludeTypesFromNamespaceOf<T>(
            this IScanningQueryComponent element)
            => element.ExcludeTypesFromNamespaceOf(typeof(T));

        public static IScanningQueryComponent IncludeOnlyTypesFromNamespaceOf(
            this IScanningQueryComponent element, Type type)
            => element.WithCustomFilter(t => !(t.Namespace?.Equals(type.Namespace) ?? false));

        public static IScanningQueryComponent IncludeOnlyTypesFromNamespaceOf<T>(
            this IScanningQueryComponent element)
            => element.IncludeOnlyTypesFromNamespaceOf(typeof(T));
    }
}