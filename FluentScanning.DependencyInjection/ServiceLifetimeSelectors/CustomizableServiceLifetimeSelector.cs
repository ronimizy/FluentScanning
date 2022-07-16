using System;
using System.Reflection;
using FluentScanning.DependencyInjection.ServiceLifetimeSelectors;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection;

internal class CustomizableServiceLifetimeSelector : IServiceLifetimeSelector
{
    private readonly Func<TypeInfo, ServiceLifetime> _selector;

    public CustomizableServiceLifetimeSelector(
        Func<TypeInfo, ServiceLifetime> selector)
    {
        _selector = selector;
    }

    public ServiceLifetime GetLifetime(TypeInfo info)
    {
        return _selector.Invoke(info);
    }
}