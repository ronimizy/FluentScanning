using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FluentScanning.DependencyInjection.ServiceLifetimeSelectors;

internal interface IServiceLifetimeSelector
{
    ServiceLifetime GetLifetime(TypeInfo info);
}