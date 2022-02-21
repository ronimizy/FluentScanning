using System;
using System.Reflection;
using FluentScanning.DependencyInjection.Queries;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    internal class CustomizableRegistrationTypeSelector : IRegistrationTypeSelector
    {
        private readonly Func<TypeInfo, Type> _selector;

        public CustomizableRegistrationTypeSelector(
            IServiceCollectionScanningQueryRoot root, Func<TypeInfo, Type> selector)
        {
            Root = root;
            _selector = selector;
        }

        public IServiceCollectionScanningQueryRoot Root { get; }

        public Type GetRegistrationType(TypeInfo info)
            => _selector.Invoke(info);
    }
}