using System;

// ReSharper disable once CheckNamespace
namespace FluentScanning;

public static class TypeFilterExtensions
{
    /// <summary>
    ///     Filters out types that are not assignable to specified type.
    /// </summary>
    /// <param name="type">Specified type.</param>
    public static IScanningQuery AreAssignableTo(this IScanningQuery query, Type type)
    {
        return query.Where(type.IsAssignableFrom);
    }

    /// <summary>
    ///     Filters out types that are not assignable to specified type.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public static IScanningQuery AreAssignableTo<T>(this IScanningQuery query)
    {
        return query.AreAssignableTo(typeof(T));
    }

    public static IScanningQuery AreBasedOnTypesConstructedFrom(this IScanningQuery query, Type unboundedGenericType)
    {
        return query.Where(x => x.IsBasedOnTypeConstructedFrom(unboundedGenericType));
    }

    /// <summary>
    ///     Filters out types that are assignable to specified type.
    /// </summary>
    /// <param name="type">Specified type.</param>
    public static IScanningQuery AreNotAssignableTo(this IScanningQuery query, Type type)
    {
        return query.Where(t => !type.IsAssignableFrom(t));
    }

    /// <summary>
    ///     Filters out types that are assignable to specified type.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public static IScanningQuery AreNotAssignableTo<T>(this IScanningQuery query)
    {
        return query.AreNotAssignableTo(typeof(T));
    }

    /// <summary>
    ///     Filters out types that are defined in namespace of specified type.
    /// </summary>
    /// <param name="type">Specified type.</param>
    public static IScanningQuery AreNotInNamespaceOf(this IScanningQuery query, Type type)
    {
        return query.Where(t => !(t.Namespace?.Equals(type.Namespace) ?? false));
    }

    /// <summary>
    ///     Filters out types that are defined in namespace of specified type.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public static IScanningQuery AreNotInNamespaceOf<T>(this IScanningQuery query)
    {
        return query.AreNotInNamespaceOf(typeof(T));
    }

    /// <summary>
    ///     Filters out types that are defined not in namespace of specified type.
    /// </summary>
    /// <param name="type">Specified type.</param>
    public static IScanningQuery AreInNamespaceOf(this IScanningQuery query, Type type)
    {
        return query.Where(t => !(t.Namespace?.Equals(type.Namespace) ?? false));
    }

    /// <summary>
    ///     Filters out types that are defined not in namespace of specified type.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public static IScanningQuery AreInNamespaceOf<T>(this IScanningQuery query)
    {
        return query.AreInNamespaceOf(typeof(T));
    }
}