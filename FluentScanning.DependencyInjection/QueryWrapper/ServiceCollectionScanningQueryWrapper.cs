using FluentScanning.AssemblyScanningQueryComponents;
using FluentScanning.Queries;
using FluentScanning.QueryWrappers;

namespace FluentScanning.DependencyInjection.QueryWrapper;

internal class ServiceCollectionScanningQueryWrapper : IScanningQueryWrapper
{
    private readonly ServiceCollectionAssemblyScanner _scanner;

    public ServiceCollectionScanningQueryWrapper(ServiceCollectionAssemblyScanner scanner)
    {
        _scanner = scanner;
    }

    public IScanningQueryInternal Wrap(IScanningQueryInternal query, IScanningQueryComponent component)
    {
        var serviceCollectionQuery = query.EnsureIs<IServiceCollectionScanningQueryInternal>();
        var next = new WrappingServiceCollectionScanningQuery(serviceCollectionQuery, component);

        _scanner.Withdraw(serviceCollectionQuery);
        _scanner.Apply(next);

        return next;
    }
}