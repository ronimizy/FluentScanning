using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.DependencyInjection.Exceptions;
using FluentScanning.DependencyInjection.Queries;

namespace FluentScanning.DependencyInjection;

public class ConstructedFromTypeSelector : IRegistrationTypeSelector
{
    private readonly Type _type;

    public ConstructedFromTypeSelector(IServiceCollectionScanningQueryRoot root, Type type)
    {
        Root = root;
        _type = type;
    }

    public IServiceCollectionScanningQueryRoot Root { get; }

    public IEnumerable<Type> GetRegistrationTypes(TypeInfo info)
    {
        Type[] baseTypeConstructedFrom = info
            .ImplementedInterfaces
            .Append(info.BaseType)
            .Where(t => t.IsConstructedFrom(_type))
            .ToArray();

        if (baseTypeConstructedFrom.Length is 0)
            throw SequenceContainsNoMatchingElement(info, _type);

        return baseTypeConstructedFrom;
    }

    private static InconclusiveTypeResolutionException SequenceContainsNoMatchingElement(Type type, Type baseType)
    {
        var message = $"Type {type} does not have any type that was constructed from {baseType} in it's base list.";
        return new InconclusiveTypeResolutionException(message);
    }
}