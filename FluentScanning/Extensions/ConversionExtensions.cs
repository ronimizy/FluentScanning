using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace FluentScanning
{
    public static class ConversionExtensions
    {
        /// <summary>
        /// Converts given TypeInfo's to types that they are describing
        /// </summary>
        public static IEnumerable<Type> AsTypes(this IEnumerable<TypeInfo> typeInfos)
            => typeInfos.Select(t => t.AsType());
    }
}