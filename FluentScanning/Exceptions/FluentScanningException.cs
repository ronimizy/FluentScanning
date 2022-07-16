using System;

namespace FluentScanning.Exceptions;

public abstract class FluentScanningException : Exception
{
    protected FluentScanningException() { }
    protected FluentScanningException(string message) : base(message) { }
    protected FluentScanningException(string message, Exception innerException) : base(message, innerException) { }
}