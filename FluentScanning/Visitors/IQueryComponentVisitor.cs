using System.Collections.Generic;
using System.Reflection;
using FluentScanning.QueryComponents;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public interface IQueryComponentVisitor
    {
        IEnumerable<TypeInfo> ApplyQuery(IEnumerable<TypeInfo> enumerable);
    }
}