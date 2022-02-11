namespace FluentScanning.QueryComponents
{
    public abstract class ComponentBase<TVisitor> : IScanningQueryComponent
        where TVisitor : IQueryComponentVisitor
    {
        public void Accept(IQueryComponentVisitor visitor)
        {
            if (visitor is TVisitor typedVisitor)
            {
                Accept(typedVisitor);
            }
        }

        protected abstract void Accept(TVisitor visitor);
    }
}