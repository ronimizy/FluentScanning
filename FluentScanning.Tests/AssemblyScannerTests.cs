using System.Collections;
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
        var baseQuery = scanner.ScanForTypesThat()
            .AreAssignableTo<Base>();

        var collectionTypes = baseQuery
            .AreAssignableTo<ICollection>()
            .AsTypes()
            .ToArray();
        
        var notAbstractTypes = baseQuery
            .AreNotAbstractClasses()
            .AsTypes()
            .ToArray();

        var collectionTypesExpected = new[] { typeof(C) };
        var notAbstractTypesExpected = new[] { typeof(A), typeof(B), typeof(C), typeof(D) };

        CollectionAssert.AreEquivalent(collectionTypesExpected, collectionTypes);
        CollectionAssert.AreEquivalent(notAbstractTypesExpected, notAbstractTypes);
    }
}