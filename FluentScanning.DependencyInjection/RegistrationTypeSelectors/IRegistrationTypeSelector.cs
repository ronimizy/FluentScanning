using System;
using System.Collections.Generic;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace FluentScanning.DependencyInjection;

internal interface IRegistrationTypeSelector
{
    IEnumerable<Type> GetRegistrationTypes(TypeInfo info);
}