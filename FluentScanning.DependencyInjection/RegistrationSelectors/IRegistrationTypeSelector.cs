using System;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.DependencyInjection.Queries;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public interface IRegistrationTypeSelector
    {
        IServiceCollectionScanningQueryRoot Root { get; }

        IEnumerable<Type> GetRegistrationTypes(TypeInfo info);
    }
}