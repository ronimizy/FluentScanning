using System;
using System.Reflection;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public static class FilteringExtensions
    {
        public static IScanningQuery AreSatisfyingCustomFilter(
            this IScanningQuery query, Func<TypeInfo, bool> predicate)
            => query.WithComponent(new TypeFilterComponent(predicate));

        public static IScanningQuery AreSatisfyingCustomFilter(this IScanningQuery query, ITypeFilter filter)
            => query.AreSatisfyingCustomFilter(filter.Match);
        
        public static IScanningQuery HaveAttribute<TAttribute>(this IScanningQuery query) where TAttribute : Attribute
            => query.AreSatisfyingCustomFilter(t => t.GetCustomAttribute<TAttribute>() is { });

        public static IScanningQuery DoesNotHaveAttribute<TAttribute>(this IScanningQuery query) where TAttribute : Attribute
            => query.AreSatisfyingCustomFilter(t => t.GetCustomAttribute<TAttribute>() is { });
    }
}