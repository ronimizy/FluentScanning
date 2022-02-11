using System;
using System.Collections.Generic;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public interface IScanningQueryComponent : IEnumerable<TypeInfo>
    {
        IScanningQueryComponent Wrap(Func<IScanningQueryComponent, IScanningQueryComponent> wrapper);
        IQueryComponentVisitor Accept(IQueryComponentVisitor visitor);
    }
}