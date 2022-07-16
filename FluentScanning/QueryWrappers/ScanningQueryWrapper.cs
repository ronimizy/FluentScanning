using FluentScanning.AssemblyScanningQueries;
using FluentScanning.AssemblyScanningQueryComponents;
using FluentScanning.Queries;
using FluentScanning.QueryWrappers;

namespace FluentScanning.AssemblyScanningQueryWrappers;

internal class ScanningQueryWrapper : IScanningQueryWrapper
{
    public IScanningQueryInternal Wrap(
        IScanningQueryInternal query,
        IScanningQueryComponent componentOld)
    {
        return new WrappingScanningQuery(query, componentOld);
    }
}