using System.Collections;
using System.Collections.Generic;
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
            .MustBeAssignableTo<Base>();

        var collectionTypes = baseQuery
            .MayBeAssignableTo<ICollection>()
            .MayBeAssignableTo<IReadOnlyCollection<object>>()
            .AsTypes()
            .ToArray();
        
        var notAbstractTypes = baseQuery
            .AreNotAbstractClasses()
            .AsTypes()
            .ToArray();

        var collectionTypesExpected = new[] { typeof(C), typeof(D) };
        var notAbstractTypesExpected = new[] { typeof(A), typeof(B), typeof(C), typeof(D) };

        CollectionAssert.AreEquivalent(collectionTypesExpected, collectionTypes);
        CollectionAssert.AreEquivalent(notAbstractTypesExpected, notAbstractTypes);
    }
}