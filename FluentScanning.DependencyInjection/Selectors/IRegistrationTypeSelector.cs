using System;
using System.Reflection;
using FluentScanning.DependencyInjection.Queries;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public interface IRegistrationTypeSelector
    {
        IServiceCollectionScanningQueryRoot Root { get; }

        Type GetRegistrationType(TypeInfo info);
    }
}