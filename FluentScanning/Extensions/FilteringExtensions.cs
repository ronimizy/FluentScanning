using System;
using System.Reflection;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public static class FilteringExtensions
    {
        /// <summary>
        /// Adds a filter to the query defined by user passed function.
        /// </summary>
        public static IScanningQuery AreSatisfyingCustomFilter(
            this IScanningQuery query, Func<TypeInfo, bool> predicate)
            => query.WithComponent(new TypeFilterComponent(predicate));

        /// <summary>
        /// Adds a filter to the query defined by ITypeFilterObject.
        /// </summary>
        public static IScanningQuery AreSatisfyingCustomFilter(this IScanningQuery query, ITypeFilter filter)
            => query.AreSatisfyingCustomFilter(filter.Match);

        /// <summary>
        /// Filters out types that are not marked with specified attribute.
        /// </summary>
        public static IScanningQuery HaveAttribute(this IScanningQuery query, Type attributeType)
            => query.AreSatisfyingCustomFilter(t => t.GetCustomAttribute(attributeType) is object);

        /// <inheritdoc cref="HaveAttribute"/>
        public static IScanningQuery HaveAttribute<TAttribute>(this IScanningQuery query) where TAttribute : Attribute
            => query.HaveAttribute(typeof(TAttribute));

        /// <summary>
        /// Filters out types that are marked with specified attribute.
        /// </summary>
        public static IScanningQuery DoesNotHaveAttribute(this IScanningQuery query, Type attributeType)
            => query.AreSatisfyingCustomFilter(t => t.GetCustomAttribute(attributeType) is object);

        /// <inheritdoc cref="DoesNotHaveAttribute"/>
        public static IScanningQuery DoesNotHaveAttribute<TAttribute>(this IScanningQuery query)
            where TAttribute : Attribute
            => query.DoesNotHaveAttribute(typeof(TAttribute));
    }
}