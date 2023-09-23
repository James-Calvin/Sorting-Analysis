using System;

class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Hello world.");
    Sortable<int> numbers = new Sortable<int>();
    int n = 10;
    for (int i = 1; i <= n; i++)
    {
      numbers.Add(i);
    }
    numbers.ShuffleGuaranteedNotSorted();
    Console.WriteLine(numbers);

    // Radix
    RadixSort radix = new();
    Console.WriteLine(radix.Execute(numbers));

    // Bogosort
    if (numbers.Count < 12)
    {
      // Reset list
      numbers.ShuffleGuaranteedNotSorted();
      Console.WriteLine(numbers);

      // Sort
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