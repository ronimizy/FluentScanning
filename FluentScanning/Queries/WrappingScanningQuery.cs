using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FluentScanning.AssemblyScanningQueryComponents;
using FluentScanning.Queries;
using FluentScanning.QueryWrappers;

namespace FluentScanning.AssemblyScanningQueries;

internal class WrappingScanningQuery : IScanningQueryInternal
{
    private readonly IScanningQueryComponent _component;
    private readonly IScanningQueryInternal _previous;

    public WrappingScanningQuery(
        IScanningQueryInternal previous,
        IScanningQueryComponent component)
    {
        _previous = previous;
        _component = component;
    }

    public IEnumerator<TypeInfo> GetEnumerator()
    {
        return _component.Filter(_previous).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IScanningQueryWrapper Wrapper => _previous.Wrapper;
}