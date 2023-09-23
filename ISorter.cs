using System;

// On implementation of an interface, you must override all of its methods
// Thus, modifying this will break all implementations of ISorter.
interface ISorter<T> where T : IComparable<T>
{
  public Sortable<T> Execute(Sortable<T> collection);
}