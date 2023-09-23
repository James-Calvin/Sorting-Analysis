using System;

class Program
{
  public static void VerboseReset(Sortable<int> sortable)
  {
    sortable.ShuffleGuaranteedNotSorted();
    Console.Write("Resetting the list: ");
    Console.WriteLine(sortable);
  }

  public static void Main(string[] args)
  {
    Console.WriteLine("Hello world.");
    Sortable<int> numbers = new Sortable<int>();
    int n = 10;
    for (int i = 1; i <= n; i++)
    {
      numbers.Add(i);
    }

    // Radix
    Console.WriteLine();
    VerboseReset(numbers);
    Console.WriteLine("Sorting with Radix:");
    RadixSort radix = new();
    Console.WriteLine(radix.Execute(numbers));

    // Heap
    Console.WriteLine();
    VerboseReset(numbers);
    Console.WriteLine("Sorting with Heap:");
    HeapSort<int> heap = new();
    Console.WriteLine(heap.Execute(numbers));

    // Bogosort
    Console.WriteLine();
    if (numbers.Count < 12)
    {
      VerboseReset(numbers);
      Console.WriteLine("Sorting with Bogo:");
      BogoSort<int> bogo = new();
      Console.WriteLine(bogo.Execute(numbers));
      Console.WriteLine(bogo.Iterations);
    }
    else
    {
      Console.WriteLine("Skipped BogoSort due to too many elements");
    }
  }
}