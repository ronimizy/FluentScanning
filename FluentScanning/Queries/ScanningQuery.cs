using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.QueryWrappers;

namespace FluentScanning.Queries;

internal class ScanningQuery : IScanningQueryInternal
{
    private readonly IEnumerable<TypeInfo> _enumerable;

    public ScanningQuery(IEnumerable<TypeInfo> enumerable, IScanningQueryWrapper wrapper)
    {
        _enumerable = enumerable;
        Wrapper = wrapper;
    }

    public IEnumerator<TypeInfo> GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IScanningQueryWrapper Wrapper { get; }
}