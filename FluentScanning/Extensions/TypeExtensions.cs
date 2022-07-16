using System;
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

        return typeInfo.ImplementedInterfaces.Append(typeInfo.BaseType)
            .Any(t => t?.IsConstructedFrom(source) ?? false);
    }
}