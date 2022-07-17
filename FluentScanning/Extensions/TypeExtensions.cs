using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentScanning;

internal static class TypeExtensions
{
    public static bool IsConstructedFrom(this Type type, Type source)
    {
        if (!type.IsConstructedGenericType)
            return type == source;

        var genericType = type.GetGenericTypeDefinition();
        return genericType == source;
    }

    public static bool IsBasedOnTypeConstructedFrom(this Type type, Type source)
    {
        if (type is not TypeInfo typeInfo)
            return type.IsConstructedFrom(source);

        return typeInfo.GetFullHierarchy().Any(t => t.IsConstructedFrom(source));
    }

    public static IEnumerable<Type> GetFullHierarchy(this Type type)
    {
        if (type is not TypeInfo typeInfo)
            return type.BaseType?.GetFullHierarchy().Append(type.BaseType) ?? Enumerable.Empty<TypeInfo>();

        return typeInfo.ImplementedInterfaces.Append(typeInfo.BaseType)
            .SelectMany(x => x?.GetFullHierarchy().Append(x) ?? Enumerable.Empty<Type>());
    }
}