using System;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public static class TypeFilterExtensions
    {
        /// <summary>
        /// Filters out types that are not assignable to specified type.
        /// </summary>
        /// <param name="type">Specified type.</param>
        public static IScanningQuery MustBeAssignableTo(this IScanningQuery query, Type type)
            => query.WithComponent(new MustBeAssignableToTypeComponent(type));

        /// <summary>
        /// Filters out types that are not assignable to specified type.
        /// </summary>
        /// <typeparam name="T">Specified type.</typeparam>
        public static IScanningQuery MustBeAssignableTo<T>(this IScanningQuery query)
            => query.MustBeAssignableTo(typeof(T));

        /// <inheritdoc cref="MayBeAssignableToTypeComponent"/>
        public static IScanningQuery MayBeAssignableTo(this IScanningQuery query, Type type)
            => query.WithComponent(new MayBeAssignableToTypeComponent(type));

        /// <inheritdoc cref="MayBeAssignableToTypeComponent"/>
        public static IScanningQuery MayBeAssignableTo<T>(this IScanningQuery query)
            => query.MayBeAssignableTo(typeof(T));

        /// <summary>
        /// Filters out types that are assignable to specified type.
        /// </summary>
        /// <param name="type">Specified type.</param>
        public static IScanningQuery AreNotAssignableTo(this IScanningQuery query, Type type)
            => query.AreSatisfyingCustomFilter(t => !type.IsAssignableFrom(t));

        /// <summary>
        /// Filters out types that are assignable to specified type.
        /// </summary>
        /// <typeparam name="T">Specified type.</typeparam>
        public static IScanningQuery AreNotAssignableTo<T>(this IScanningQuery query)
            => query.AreNotAssignableTo(typeof(T));

        /// <summary>
        /// Filters out types that are defined in namespace of specified type.
        /// </summary>
        /// <param name="type">Specified type.</param>
        public static IScanningQuery AreNotInNamespaceOf(this IScanningQuery query, Type type)
            => query.AreSatisfyingCustomFilter(t => !(t.Namespace?.Equals(type.Namespace) ?? false));

        /// <summary>
        /// Filters out types that are defined in namespace of specified type.
        /// </summary>
        /// <typeparam name="T">Specified type.</typeparam>
        public static IScanningQuery AreNotInNamespaceOf<T>(this IScanningQuery query)
            => query.AreNotInNamespaceOf(typeof(T));

        /// <summary>
        /// Filters out types that are defined not in namespace of specified type.
        /// </summary>
        /// <param name="type">Specified type.</param>
        public static IScanningQuery AreInNamespaceOf(this IScanningQuery query, Type type)
            => query.AreSatisfyingCustomFilter(t => !(t.Namespace?.Equals(type.Namespace) ?? false));

        /// <summary>
        /// Filters out types that are defined not in namespace of specified type.
        /// </summary>
        /// <typeparam name="T">Specified type.</typeparam>
        public static IScanningQuery AreInNamespaceOf<T>(this IScanningQuery query)
            => query.AreInNamespaceOf(typeof(T));
    }
}