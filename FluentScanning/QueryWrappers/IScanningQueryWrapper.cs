using FluentScanning.AssemblyScanningQueryComponents;
using FluentScanning.Queries;

namespace FluentScanning.QueryWrappers;

internal interface IScanningQueryWrapper
{
    IScanningQueryInternal Wrap(
        IScanningQueryInternal query,
        IScanningQueryComponent componentOld);
}