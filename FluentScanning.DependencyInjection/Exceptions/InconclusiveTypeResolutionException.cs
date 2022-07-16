using FluentScanning.Exceptions;

namespace FluentScanning.DependencyInjection;

public class InconclusiveTypeResolutionException : FluentScanningException
{
    internal InconclusiveTypeResolutionException(string message) : base(message) { }
}