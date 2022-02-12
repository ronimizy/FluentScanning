using System;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public readonly struct AssemblyProvider
    {
        private readonly Lazy<Assembly> _lazyAssembly;

        private AssemblyProvider(Func<Assembly> factory)
        {
            _lazyAssembly = new Lazy<Assembly>(factory);
        }

        public Assembly Assembly => _lazyAssembly.Value;

        public static implicit operator AssemblyProvider(Type type)
            => new AssemblyProvider(() => type.Assembly);

        public static implicit operator AssemblyProvider(Assembly assembly)
            => new AssemblyProvider(() => assembly);
    }
}