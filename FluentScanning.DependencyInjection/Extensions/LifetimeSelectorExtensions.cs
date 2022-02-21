using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public static class LifetimeSelectorExtensions
    {
        public static IScanningQuery WithLifetimeOf(
            this IRegistrationTypeSelector registrationTypeSelector, ServiceLifetime lifetime)
            => new CustomizableServiceLifetimeSelector(registrationTypeSelector, _ => lifetime);
        
        public static IScanningQuery WithSingletonLifetime(this IRegistrationTypeSelector selector)
            => selector.WithLifetimeOf(ServiceLifetime.Singleton);

        public static IScanningQuery WithScopedLifetime(this IRegistrationTypeSelector selector)
            => selector.WithLifetimeOf(ServiceLifetime.Scoped);

        public static IScanningQuery WithTransientLifetime(this IRegistrationTypeSelector selector)
            => selector.WithLifetimeOf(ServiceLifetime.Transient);
    }
}