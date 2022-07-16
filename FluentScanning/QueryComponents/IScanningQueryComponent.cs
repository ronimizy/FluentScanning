using System.Collections.Generic;
using System.Reflection;

namespace FluentScanning.AssemblyScanningQueryComponents;

internal interface IScanningQueryComponent
{
    IEnumerable<TypeInfo> Filter(IEnumerable<TypeInfo> types);
}