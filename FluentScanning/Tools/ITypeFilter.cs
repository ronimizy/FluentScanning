using System.Reflection;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public interface ITypeFilter
    {
        bool Match(TypeInfo type);
    }
}