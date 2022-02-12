using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public static class LifetimeSelectorExtensions
    {
        public static IScanningQuery WithSingletonLifetime(this ServiceLifetimeSelector selector)
            => selector.WithLifetimeOf(ServiceLifetime.Singleton);

        public static IScanningQuery WithScopedLifetime(this ServiceLifetimeSelector selector)
            => selector.WithLifetimeOf(ServiceLifetime.Scoped);

        public static IScanningQuery WithTransientLifetime(this ServiceLifetimeSelector selector)
            => selector.WithLifetimeOf(ServiceLifetime.Transient);
    }
}