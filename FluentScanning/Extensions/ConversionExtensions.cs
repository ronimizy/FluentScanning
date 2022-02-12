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
        /// Not really necessary as TypeInfo is derived from Type and assigning it to Type variable will give you the Type that it describing.
        /// </summary>
        /// <returns>IEnumerable of Types that given TypeInfos describing.</returns>
        public static IEnumerable<Type> AsTypes(this IEnumerable<TypeInfo> typeInfos)
            => typeInfos.Select(t => t.AsType());
    }
}