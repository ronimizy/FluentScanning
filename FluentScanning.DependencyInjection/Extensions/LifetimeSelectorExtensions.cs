using FluentScanning.DependencyInjection.QueryRegistrationTypeProviders;
using Microsoft.Extensions.DependencyInjection;

namespace FluentScanning.DependencyInjection;

public static class LifetimeSelectorExtensions
{
    public static IScanningQuery WithLifetimeOf(
        this IScanningQueryRegistrationTypeProvider typeProvider,
        ServiceLifetime lifetime)
    {
        var selector = new CustomizableServiceLifetimeSelector(_ => lifetime);
        var typeProviderInternal = typeProvider.EnsureIs<IScanningQueryRegistrationTypeProviderInternal>();

        return new ServiceCollectionScanningQuery(
            typeProviderInternal.Enumerable,
            typeProviderInternal.Wrapper,
            typeProviderInternal.RegistrationTypeSelector,
            selector);
    }

    public static IScanningQuery WithSingletonLifetime(this IScanningQueryRegistrationTypeProvider selector)
    {
        return selector.WithLifetimeOf(ServiceLifetime.Singleton);
    }

    public static IScanningQuery WithScopedLifetime(this IScanningQueryRegistrationTypeProvider selector)
    {
        return selector.WithLifetimeOf(ServiceLifetime.Scoped);
    }

    public static IScanningQuery WithTransientLifetime(this IScanningQueryRegistrationTypeProvider selector)
    {
        return selector.WithLifetimeOf(ServiceLifetime.Transient);
    }
}