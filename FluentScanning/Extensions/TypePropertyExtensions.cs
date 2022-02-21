// ReSharper disable once CheckNamespace

namespace FluentScanning
{
    public static class TypePropertyExtensions
    {
        /// <summary>
        /// Filters out types that are interfaces.
        /// </summary>
        public static IScanningQuery AreNotInterfaces(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsInterface);

        /// <summary>
        /// Filters out types that are abstract classes.
        /// </summary>
        public static IScanningQuery AreNotAbstractClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsAbstract);

        /// <summary>
        /// Filters out types that are not interfaces.
        /// </summary>
        public static IScanningQuery AreInterfaces(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsInterface);

        /// <summary>
        /// Filters out types that are not abstract classes.
        /// </summary>
        public static IScanningQuery AreAbstractClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsAbstract);

        /// <summary>
        /// Filters out types that are not public.
        /// </summary>
        public static IScanningQuery ArePublic(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsPublic);

        /// <summary>
        /// Filters out types that are public.
        /// </summary>
        public static IScanningQuery AreNotPublic(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsNotPublic);

        /// <summary>
        /// Filters out types that are not classes.
        /// </summary>
        public static IScanningQuery AreClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsClass);

        /// <summary>
        /// Filters out types that are classes.
        /// </summary>
        public static IScanningQuery AreNotClasses(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsClass);

        /// <summary>
        /// Filters out types that are not value types.
        /// </summary>
        public static IScanningQuery AreValueTypes(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => t.IsValueType);

        /// <summary>
        /// Filters out types that are value types.
        /// </summary>
        public static IScanningQuery AreNotValueTypes(this IScanningQuery query)
            => query.AreSatisfyingCustomFilter(t => !t.IsValueType);
    }
}