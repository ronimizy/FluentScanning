using FluentScanning.QueryWrappers;

namespace FluentScanning.Queries;

internal interface IScanningQueryInternal : IScanningQuery
{
    IScanningQueryWrapper Wrapper { get; }
}