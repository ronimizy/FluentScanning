# FluentScanning [![Nuget](https://img.shields.io/nuget/v/FluentScanning?style=flat-square)](https://www.nuget.org/packages/FluentScanning/)

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
    .AreInterfaces()
    .ToArray();

var notAbstractQuerty = baseQuery
    .AreNotAbstractClasses()
    // As the IScanningQuery implements IEnumerble<TypeInfo> you can use .AsType to convert it 
    // to  IEnumerable<Type> and enumerate over it.
    .AsTypes()
    .ToArray();
```

# FluentScanning.DependencyInjection [![Nuget](https://img.shields.io/nuget/v/FluentScanning.DependencyInjection?style=flat-square)](https://www.nuget.org/packages/FluentScanning.DependencyInjection/)

A package that provide functionality for adding assembly scanning results to
Microsoft.Extensions.DependencyInjection.IServiceCollection

The use of IDisposable pattern implemented to make scanning to IServiceCollection clean and explicit.\
**BE AWARE!** The types are being added to the collection only after scanner is disposed.\
As IScanningQuery support query branching, only "dangling" queries are added to IServiceCollection, but not the
branching roots.

```cs
IServiceCollection collection = new ServiceCollection();

// Obtaining scanner from IServiceCollection, defining scanning scope 
// just like with AssemblyScanner's constructor.
using (var scanner = collection.UseAssemblyScanner(typeof(IAssemblyMarker)))
{
    // Query result would not be added to IServiceCollection.
    var baseQuery = scanner.EnqueueAdditionOfTypesThat()
        .WouldBeRegisteredAs<Base>()
        .WithSingletonLifetime()
        .MustBeAssignableTo<Base>();
        
    // Queries results will be added to IServiceCollection.
    baseQuery.AreNotAbstractClasses();
    baseQuery.AreValueTypes();
}
```

## Registration as type constructed from given type

> Unbound generic type is a generic type that does not have all his generic parameters bound with types, nor with type parameters. 
> It can only be obtained as a runtime type by using `typeof(IGeneric<>)` statement or through reflection. 

> When you populate a generic type with a type arguments or parameters, your open or closed generic type would be constructed from that unbounded generic type.

You can register types as type constructed from given type using `.WouldBeRegisteredAsTypesConstructedFrom` extension method.
As well as filtering types that are based on a type that is constructed from given type using `.AreBasedOnTypesConstructedFrom` extension method.

```csharp
using (var scanner = collection.UseAssemblyScanner(typeof(IAssemblyMarker)))
{
    scanner.EnqueueAdditionOfTypesThat()
        .WouldBeRegisteredAsTypesConstructedFrom(typeof(IGeneric<>))
        .WithSingletonLifetime()
        .AreBasedOnTypesConstructedFrom(typeof(IGeneric<>))
        .AreNotAbstractClasses()
        .AreNotInterfaces();
}
```