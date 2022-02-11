// See https://aka.ms/new-console-template for more information

using FluentScanning;

var scanner = new AssemblyScanner(typeof(IAssemblyMarker));

var types = scanner.MustBeAssignableTo<A>().ExcludeAbstractClasses().ToArray();

foreach (var t in types)
{
    Console.WriteLine(t);
}

interface IAssemblyMarker { }

abstract class A { }

class B : A { }

class C : A { }

class D { }