using FluentScanning.DependencyInjection.ServiceLifetimeSelectors;
using FluentScanning.Queries;

namespace FluentScanning.DependencyInjection;

internal interface IServiceCollectionScanningQueryInternal : IScanningQueryInternal
{
    IRegistrationTypeSelector RegistrationTypeSelector { get; }

    IServiceLifetimeSelector LifetimeSelector { get; }
}