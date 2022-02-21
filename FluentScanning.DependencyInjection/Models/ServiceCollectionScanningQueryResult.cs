using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FluentScanning.DependencyInjection.Models
{
    internal struct ServiceCollectionScanningQueryResult
    {
        public ServiceCollectionScanningQueryResult(
            IEnumerable<TypeInfo> typeInfos, 
            IRegistrationTypeSelector registrationTypeSelector,
            IServiceLifetimeSelector serviceLifetimeSelector)
        {
            TypeInfos = typeInfos;
            RegistrationTypeSelector = registrationTypeSelector;
            ServiceLifetimeSelector = serviceLifetimeSelector;
        }

        internal IEnumerable<TypeInfo> TypeInfos { get; }
        internal IRegistrationTypeSelector RegistrationTypeSelector { get; }
        internal IServiceLifetimeSelector ServiceLifetimeSelector { get; }
    }
}