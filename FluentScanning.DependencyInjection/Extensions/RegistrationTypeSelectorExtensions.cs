using System;
using FluentScanning.DependencyInjection.QueryRegistrationTypeProviders;
using FluentScanning.DependencyInjection.QueryRoots;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection;

public static class RegistrationTypeSelectorExtensions
{
    /// <summary>
    ///     Declares a registration type selection protocol.
    /// </summary>
    /// <param name="type">Type that query results would be registered as.</param>
    public static IScanningQueryRegistrationTypeProvider WouldBeRegisteredAs(
        this IServiceCollectionScanningQueryRoot root,
        Type type)
    {
        var selector = new CustomizableRegistrationTypeSelector(_ => type);
        var rootInternal = root.EnsureIs<IServiceCollectionScanningQueryRootInternal>();

        return new ScanningQueryRegistrationTypeProvider(rootInternal.Wrapper, rootInternal.Enumerable, selector);
    }

    /// <summary>
    ///     Declares a registration type selection protocol.
    /// </summary>
    /// <typeparam name="T">Type that query results would be registered as.</typeparam>
    public static IScanningQueryRegistrationTypeProvider WouldBeRegisteredAs<T>(
        this IServiceCollectionScanningQueryRoot rootOld)
    {
        return rootOld.WouldBeRegisteredAs(typeof(T));
    }

    /// <summary>
    ///     Declares that query results would be registered in IService collection as the type they represent.
    /// </summary>
    public static IScanningQueryRegistrationTypeProvider WouldBeRegisteredAsSelfType(
        this IServiceCollectionScanningQueryRoot root)
    {
        var selector = new CustomizableRegistrationTypeSelector(t => t);
        var rootInternal = root.EnsureIs<IServiceCollectionScanningQueryRootInternal>();

        return new ScanningQueryRegistrationTypeProvider(rootInternal.Wrapper, rootInternal.Enumerable, selector);
    }

    public static IScanningQueryRegistrationTypeProvider WouldBeRegisteredAsTypesConstructedFrom(
        this IServiceCollectionScanningQueryRoot root,
        Type unboundedGenericType)
    {
        var selector = new ConstructedFromTypeSelector(unboundedGenericType);
        var rootInternal = root.EnsureIs<IServiceCollectionScanningQueryRootInternal>();

        return new ScanningQueryRegistrationTypeProvider(rootInternal.Wrapper, rootInternal.Enumerable, selector);
    }
}