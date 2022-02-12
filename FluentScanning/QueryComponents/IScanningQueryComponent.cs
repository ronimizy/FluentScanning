// ReSharper disable once CheckNamespace

namespace FluentScanning
{
    public interface IScanningQueryComponent
    {
        void Accept(IQueryComponentVisitor visitor);
    }
}