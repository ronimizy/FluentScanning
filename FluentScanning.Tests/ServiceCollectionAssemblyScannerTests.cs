using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentScanning.DependencyInjection;
using FluentScanning.Tests.Types;
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
                .MustBeAssignableTo<Base>()
                .AreNotAbstractClasses();

            baseQuery.MustBeAssignableTo<ICollection>();
            baseQuery.MustBeAssignableTo<IReadOnlyCollection<object>>();
        }

        var expected = new[] { typeof(C), typeof(D) };
        var found = collection.Select(d => d.ImplementationType);

        CollectionAssert.AreEquivalent(expected, found);
    }
}