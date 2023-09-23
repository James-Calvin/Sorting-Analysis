class RadixSort : ISorter<int>  // Limiting to 'int' for simplicity
{
  public Sortable<int> Execute(Sortable<int> collection)
  {
    int maxNumber = FindMax(collection);
    int n = collection.Count;

    // Iterate over each place value and sort
    for (int exp = 1; maxNumber / exp > 0; exp *= 10)
    {
      CountingSortByDigit(collection, exp);
    }

    return collection;
  }

  private int FindMax(Sortable<int> collection)
  {
    int max = int.MinValue;
    foreach (var value in collection.Values)
    {
      if (value > max)
        max = value;
    }
    return max;
  }

  private void CountingSortByDigit(Sortable<int> collection, int exp)
  {
    int n = collection.Count;
    int[] output = new int[n];
    int[] count = new int[10];  // Base 10, so 10 possible digits

    // Initialize count array
    for (int i = 0; i < 10; i++)
      count[i] = 0;

    // Store count of occurrences
    for (int i = 0; i < n; i++)
      count[(collection.GetValue(i) / exp) % 10]++;

    // Change count[i] to store its actual position in output
    for (int i = 1; i < 10; i++)
      count[i] += count[i - 1];

    // Build the output array
    for (int i = n - 1; i >= 0; i--)
    {
      output[count[(collection.GetValue(i) / exp) % 10] - 1] = collection.GetValue(i);
      count[(collection.GetValue(i) / exp) % 10]--;
    }

    // Copy the output array to collection, so it contains numbers sorted by current digit
    for (int i = 0; i < n; i++)
      collection.SetValue(i, output[i]); // Update the existing elements in collection
  }

}
