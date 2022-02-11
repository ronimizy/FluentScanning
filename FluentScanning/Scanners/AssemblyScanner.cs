using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public class AssemblyScanner : IAssemblyScanner
    {
        private readonly IReadOnlyCollection<AssemblyProvider> _providers;

        public AssemblyScanner(params AssemblyProvider[] providers)
        {
            _providers = providers.ToList();
        }

        public IEnumerator<TypeInfo> GetEnumerator()
            => _providers
                .Select(p => p.Assembly)
                .SelectMany(a => a.DefinedTypes)
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public IScanningQueryComponent Wrap(Func<IScanningQueryComponent, IScanningQueryComponent> wrapper)
            => new EnclosingComponent(wrapper.Invoke(this));

        public IQueryComponentVisitor Accept(IQueryComponentVisitor visitor)
            => visitor;
    }
}