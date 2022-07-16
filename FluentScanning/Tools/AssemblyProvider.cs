using System;
using System.Reflection;

namespace FluentScanning;

public readonly struct AssemblyProvider
{
    private readonly Lazy<Assembly> _lazyAssembly;

    private AssemblyProvider(Func<Assembly> factory)
    {
        _lazyAssembly = new Lazy<Assembly>(factory);
    }

    public Assembly Assembly => _lazyAssembly.Value;

    public static implicit operator AssemblyProvider(Type type)
    {
        return new AssemblyProvider(() => type.Assembly);
    }

    public static implicit operator AssemblyProvider(Assembly assembly)
    {
        return new AssemblyProvider(() => assembly);
    }

    public static implicit operator AssemblyProvider(Func<Type> func)
    {
        return new AssemblyProvider(() => func.Invoke().Assembly);
    }

    public static implicit operator AssemblyProvider(Func<Assembly> func)
    {
        return new AssemblyProvider(func);
    }
}