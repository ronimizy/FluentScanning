using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection;

internal class CustomizableRegistrationTypeSelector : IRegistrationTypeSelector
{
    private readonly Func<TypeInfo, Type> _selector;

    public CustomizableRegistrationTypeSelector(Func<TypeInfo, Type> selector)
    {
        _selector = selector;
    }

    public IEnumerable<Type> GetRegistrationTypes(TypeInfo info)
    {
        return Enumerable.Repeat(_selector.Invoke(info), 1);
    }
}