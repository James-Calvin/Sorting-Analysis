using System;

class BogoSort<T> : ISorter<T> where T : IComparable<T>
{
  private int? iterations = null; // For debugging

  public Sortable<T> Execute(Sortable<T> collection)
  {

    iterations = 0; // Debugging information
    while (!collection.IsSorted())
    {
      collection.Shuffle();
      iterations++;
    }
    return collection;
  }

  public int? Iterations
  {
    get { return iterations; }
  }
}
