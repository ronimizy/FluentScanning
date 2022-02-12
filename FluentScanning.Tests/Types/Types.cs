using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentScanning.Tests.Types;

public interface IAssemblyMarker { }

public abstract class Base { }

public class A : Base { }

public class B : Base { }

public class C : Base, ICollection
{
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }
    public bool IsSynchronized { get; }
    public object SyncRoot { get; }
}

public class D : Base, IReadOnlyCollection<object>
{
    public IEnumerator<object> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count { get; }
}