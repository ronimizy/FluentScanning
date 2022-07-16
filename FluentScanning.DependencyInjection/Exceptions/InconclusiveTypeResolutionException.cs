using FluentScanning.Exceptions;

namespace FluentScanning.DependencyInjection.Exceptions;

public class InconclusiveTypeResolutionException : FluentScanningException
{
    internal InconclusiveTypeResolutionException(string message) : base(message) { }
}