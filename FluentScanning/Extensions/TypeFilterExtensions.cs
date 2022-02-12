using System;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public static class TypeFilterExtensions
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

        public static IScanningQuery AreNotAssignableTo(this IScanningQuery query, Type type)
            => query.AreSatisfyingCustomFilter(t => !type.IsAssignableFrom(t));

        public static IScanningQuery AreNotAssignableTo<T>(this IScanningQuery query)
            => query.AreNotAssignableTo(typeof(T));

        public static IScanningQuery AreNotInNamespaceOf(this IScanningQuery query, Type type)
            => query.AreSatisfyingCustomFilter(t => !(t.Namespace?.Equals(type.Namespace) ?? false));

        public static IScanningQuery AreNotInNamespaceOf<T>(this IScanningQuery query)
            => query.AreNotInNamespaceOf(typeof(T));

        public static IScanningQuery AreInNamespaceOf(this IScanningQuery query, Type type)
            => query.AreSatisfyingCustomFilter(t => !(t.Namespace?.Equals(type.Namespace) ?? false));

        public static IScanningQuery AreInNamespaceOf<T>(this IScanningQuery query)
            => query.AreInNamespaceOf(typeof(T));
    }
}