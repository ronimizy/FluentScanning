namespace FluentScanning.QueryComponents
{
    public class EnclosingComponent : EnclosingComponentBase
    {
        public EnclosingComponent(IScanningQueryComponent component)
            : base(component) { }

        protected override IScanningQueryComponent Wrap(IScanningQueryComponent component)
            => new EnclosingComponent(component);
    }
}