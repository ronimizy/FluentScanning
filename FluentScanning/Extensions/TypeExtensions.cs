using System;
using System.Linq;
using System.Reflection;

namespace FluentScanning;

public static class TypeExtensions
{
    public static bool IsConstructedFrom(this Type type, Type source)
    {
        if (!type.IsConstructedGenericType)
            return type == source;

        var genericType = type.GetGenericTypeDefinition();
        return genericType == source;
    }

    public static bool IsBasedOn(this TypeInfo type, Type source)
    {
        return source.IsAssignableFrom(type) ||
               type.ImplementedInterfaces.Append(type.BaseType).Any(t => t?.IsConstructedFrom(source) ?? false);
    }
}