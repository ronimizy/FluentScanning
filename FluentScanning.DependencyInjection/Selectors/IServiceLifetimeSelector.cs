using System.Reflection;
using FluentScanning.DependencyInjection.Queries;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public interface IServiceLifetimeSelector : IScanningQuery
    {
        IServiceCollectionScanningQueryRoot Root { get; }
        IRegistrationTypeSelector TypeSelector { get; }

        ServiceLifetime GetLifetime(TypeInfo info);
    }
}