using System;
using FluentScanning.DependencyInjection.Queries;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection
{
    public static class RegistrationTypeSelectorExtensions
    {
        /// <summary>
        /// Declares a registration type selection protocol.
        /// </summary>
        /// <param name="type">Type that query results would be registered as.</param>
        public static IRegistrationTypeSelector WouldBeRegisteredAs(
            this IServiceCollectionScanningQueryRoot root, 
            Type type)
            => new CustomizableRegistrationTypeSelector(root, _ => type);

        /// <summary>
        /// Declares a registration type selection protocol.
        /// </summary>
        /// <typeparam name="T">Type that query results would be registered as.</typeparam>
        public static IRegistrationTypeSelector WouldBeRegisteredAs<T>(this IServiceCollectionScanningQueryRoot root)
            => root.WouldBeRegisteredAs(typeof(T));

        /// <summary>
        /// Declares that query results would be registered in IService collection as the type they represent.
        /// </summary>
        public static IRegistrationTypeSelector WouldBeRegisteredAsSelfType(
            this IServiceCollectionScanningQueryRoot root)
            => new CustomizableRegistrationTypeSelector(root, t => t);
    }
}