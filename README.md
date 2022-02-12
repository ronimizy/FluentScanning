# FluentScanning

A package that provides abstraction and common functionality for performing assembly scanning.

```cs
// Creating an instance of assembly scanning with defined scanning scope.
// AsseblyScanner's constructor accepts Type, Assembly, () => Type, () => Assembly as params.
// Assemblies extracted from them form a scanning scope (assemblies are distinct).
var scanner = new AssemblyScanner(typeof(IAssemblyMarker), typeof(object));

// Start a scanning query
var baseQuery = scanner.ScanForTypesThat()
    // Use extension methods to build up a query.
    .MustBeAssignableTo<Base>();
    
// All queries are immutable and they support query branching.
// It means that you can save a mid-query and build up queries in 
// different directions just like you would do with IEnumerable / IQueriable
var collectionQuery = baseQuery
    // You can use MayBeAssignableTo extension to define a disjuction of types 
    // that are conform the query.
    // In this example query will return types that are assignable to 
    // (Base & IReadOnlyCollection<object>) || (Base & ICollection).
    .MayBeAssignableTo<IReadOnlyCollection<object>>()
    .MayBeAssignableTo<ICollection>();

var notAbstractQuerty = baseQuery
    .AreNotAbstractClasses()
    // As the IScanningQuery implements IEnumerble<TypeInfo> you can use .AsType to convert it 
    // to  IEnumerable<Type> and enumerate over it.
    .AsTypes()
    .ToArray();
```

# FluentScanning.DependencyInjection

A package that provide functionality for adding assembly scanning results to Microsoft.Extensions.DependencyInjection.IServiceCollection

The use of IDisposable pattern implemented to make scanning to IServiceCollection clean and explicit.\
**BE AWARE!** The types are being added to the collection only after scanner is disposed.\
As IScanningQuery support query branching, only "dangling" queries are added to IServiceCollection, but not the branching roots.

```cs
var collection = new ServiceCollection();

using (var scanner = collection.UseAssemblyScanner(typeof(IAssemblyMarker)))
{
    // Query result would not be added to IServiceCollection.
    var base = scanner.EnqueueAdditionOfTypesThat()
        .AreRegisteredAs<Base>()
        .WithSingletonLifetime()
        .MustBeAssignableTo<Base>();
        
    // Queries results will be added to IServiceCollection.
    base.AreNotAbstractClasses();
    base.AreValueTypes();
}
```