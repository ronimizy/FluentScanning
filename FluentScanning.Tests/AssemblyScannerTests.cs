using System.Linq;
using FluentScanning.Tests.Types;
using NUnit.Framework;

namespace FluentScanning.Tests;

[TestFixture]
public class AssemblyScannerTests
{
    [Test]
    public void FindDerivedTypesTest()
    {
        var scanner = new AssemblyScanner(typeof(IAssemblyMarker));
        var types = scanner.ScanForTypesThat()
            .MustBeAssignableTo<Base>()
            .AreNotAbstractClasses()
            .AsTypes()
            .ToArray();

        var expected = new[] { typeof(A), typeof(B) };

        CollectionAssert.AreEquivalent(expected, types);
    }
}