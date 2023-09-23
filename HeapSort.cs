using System;

class HeapSort<T> : ISorter<T> where T : IComparable<T>
{
  public Sortable<T> Execute(Sortable<T> collection)
  {
    int n = collection.Values.Count;

    // Build heap (rearrange array)
    for (int i = n / 2 - 1; i >= 0; i--)
      Heapify(collection, n, i);

    // Extract elements from heap one by one
    for (int i = n - 1; i > 0; i--)
    {
      // Move current root to end
      collection.Swap(0, i);

      // Call heapify on the reduced heap
      Heapify(collection, i, 0);
    }

    return collection;
  }

  private void Heapify(Sortable<T> collection, int n, int i)
  {
    int largest = i;  // Initialize largest as root
    int left = 2 * i + 1;  // left child
    int right = 2 * i + 2;  // right child

    // If left child is larger than root
    if (left < n && collection.Compare(left, largest) > 0)
      largest = left;

    // If right child is larger than the largest so far
    if (right < n && collection.Compare(right, largest) > 0)
      largest = right;

    // If largest is not root
    if (largest != i)
    {
      collection.Swap(i, largest);

      // Recursively heapify the affected sub-tree
      Heapify(collection, n, largest);
    }
  }
}
