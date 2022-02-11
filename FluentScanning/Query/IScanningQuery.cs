using System.Collections.Generic;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public interface IScanningQuery : IEnumerable<TypeInfo>
    {
        IScanningQuery WithComponent(IScanningQueryComponent component);
        void Accept(IQueryComponentVisitor visitor);
    }
}