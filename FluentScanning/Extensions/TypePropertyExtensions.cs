// ReSharper disable once CheckNamespace

namespace FluentScanning
{
    public static class TypePropertyExtensions
    {
        public static IScanningQuery AreNotInterfaces(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsInterface);

        public static IScanningQuery AreNotAbstractClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsAbstract);

        public static IScanningQuery AreInterfaces(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsInterface);

        public static IScanningQuery AreAbstractClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsAbstract);

        public static IScanningQuery ArePublic(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsPublic);

        public static IScanningQuery AreNotPublic(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsNotPublic);

        public static IScanningQuery AreClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsClass);

        public static IScanningQuery AreNotClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsClass);

        public static IScanningQuery AreValueTypes(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsValueType);

        public static IScanningQuery AreNotValueTypes(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsValueType);
    }
}