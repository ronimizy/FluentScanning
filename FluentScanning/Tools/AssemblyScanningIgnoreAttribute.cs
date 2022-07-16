using System;

namespace FluentScanning;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
public class AssemblyScanningIgnoreAttribute : Attribute { }