namespace FluentScanning.Exceptions;

public class InvalidScanningQueryStructureException : FluentScanningException
{
    public InvalidScanningQueryStructureException(string message)
        : base(message) { }
}