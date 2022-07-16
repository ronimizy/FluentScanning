using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentScanning.DependencyInjection;
using FluentScanning.Tests.Types;
using FluentScanning.Tests.Types.Generic;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace FluentScanning.Tests;

[TestFixture]
public class ServiceCollectionAssemblyScannerTests
{
    [Test]
    public void AddDerivedTypesTest()
    {
        var collection = new ServiceCollection();

        using (var scanner = collection.UseAssemblyScanner(typeof(IAssemblyMarker)))
        {
            var baseQuery = scanner.EnqueueAdditionOfTypesThat()
                .WouldBeRegisteredAs<Base>()
                .WithSingletonLifetime()
                .AreAssignableTo<Base>()
                .AreNotAbstractClasses();

            baseQuery.AreAssignableTo<ICollection>();
            baseQuery.AreAssignableTo<IReadOnlyCollection<object>>();
        }

        var expected = new[] { typeof(C), typeof(D) };
        var found = collection.Select(d => d.ImplementationType);

        CollectionAssert.AreEquivalent(expected, found);
    }

    [Test]
    public void ConstructedFromTest()
    {
        var collection = new ServiceCollection();

        using (var scanner = collection.UseAssemblyScanner(typeof(IAssemblyMarker)))
        {
            scanner.EnqueueAdditionOfTypesThat()
                .WouldBeRegisteredAsTypesConstructedFrom(typeof(IGeneric<>))
                .WithSingletonLifetime()
                .AreBasedOnTypesConstructedFrom(typeof(IGeneric<>))
                .AreNotAbstractClasses()
                .AreNotInterfaces();
        }

        var provider = collection.BuildServiceProvider();

        var generic = provider.GetService<IGeneric<int>>();

        Assert.NotNull(generic);
        Assert.AreEqual(typeof(IntConcrete), generic.GetType());
    }
}