using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FluentScanning.DependencyInjection.Models
{
    internal struct ServiceCollectionScanningQueryResult
    {
        public ServiceCollectionScanningQueryResult(
            IEnumerable<TypeInfo> typeInfos, Type registrationType, ServiceLifetime serviceLifetime)
        {
            TypeInfos = typeInfos;
            RegistrationType = registrationType;
            ServiceLifetime = serviceLifetime;
        }

        internal IEnumerable<TypeInfo> TypeInfos { get; }
        internal Type RegistrationType { get; }
        internal ServiceLifetime ServiceLifetime { get; }
    }
}