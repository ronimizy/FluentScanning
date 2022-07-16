using System.Runtime.CompilerServices;
using FluentScanning.Exceptions;

namespace FluentScanning;

internal static class DowncastExtensions
{
    public static TDerived EnsureIs<TDerived>(this object obj, [CallerMemberName] string? objectName = null)
    {
        if (obj is not TDerived derived)
        {
            var message = $"{objectName} must be of type {typeof(TDerived).Name}";
            throw new InvalidScanningQueryStructureException(message);
        }

        return derived;
    }
}