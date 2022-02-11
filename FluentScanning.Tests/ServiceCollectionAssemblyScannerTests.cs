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
            scanner.EnqueueAdditionOfTypesThat()
                .AreRegisteredAs<Base>()
                .WithSingletonLifetime()
                .MustBeAssignableTo<Base>()
                .AreNotAbstractClasses();
        }

        var expected = new[] { typeof(A), typeof(B) };
        var found = collection.Select(d => d.ImplementationType);

        CollectionAssert.AreEquivalent(expected, found);
    }
}