using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentScanning.AssemblyScanningQueryComponents;

internal class LambdaQueryComponent : IScanningQueryComponent
{
    private readonly Func<TypeInfo, bool> _func;

    public LambdaQueryComponent(Func<TypeInfo, bool> func)
    {
        _func = func;
    }

    public IEnumerable<TypeInfo> Filter(IEnumerable<TypeInfo> types)
    {
        return types.Where(_func);
    }
}