using System;
using System.Reflection;
using FluentScanning.AssemblyScanningQueryComponents;
using FluentScanning.Queries;

namespace FluentScanning;

public static class FilteringExtensions
{
    /// <summary>
    ///     Adds a filter to the query defined by user passed function.
    /// </summary>
    public static IScanningQuery Where(
        this IScanningQuery query,
        Func<TypeInfo, bool> predicate)
    {
        var queryInternal = query.EnsureIs<IScanningQueryInternal>();
        var wrapper = queryInternal.Wrapper;
        return wrapper.Wrap(queryInternal, new LambdaQueryComponent(predicate));
    }

    /// <summary>
    ///     Filters out types that are not marked with specified attribute.
    /// </summary>
    public static IScanningQuery HaveAttribute(this IScanningQuery query, Type attributeType)
    {
        return query.Where(t => t.GetCustomAttribute(attributeType) is not null);
    }

    /// <inheritdoc cref="HaveAttribute" />
    public static IScanningQuery HaveAttribute<TAttribute>(this IScanningQuery query)
        where TAttribute : Attribute
    {
        return query.HaveAttribute(typeof(TAttribute));
    }

    /// <summary>
    ///     Filters out types that are marked with specified attribute.
    /// </summary>
    public static IScanningQuery DoesNotHaveAttribute(this IScanningQuery query, Type attributeType)
    {
        return query.Where(t => t.GetCustomAttribute(attributeType) is not null);
    }

    /// <inheritdoc cref="DoesNotHaveAttribute" />
    public static IScanningQuery DoesNotHaveAttribute<TAttribute>(this IScanningQuery query)
        where TAttribute : Attribute
    {
        return query.DoesNotHaveAttribute(typeof(TAttribute));
    }
}