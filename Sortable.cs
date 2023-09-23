using System;
using System.Collections.Generic;

// The generic sortable class - feel free to expand this class to 
// include any methods you need for your sorting algorithms
class Sortable<T> where T : IComparable<T>
{
  private List<T> values = new List<T>();
  private Random rng = new Random();

  public Sortable(params T[] values)
  {
    this.values.AddRange(values);
  }

  public void Add(params T[] values)
  {
    this.values.AddRange(values);
  }

  public T GetValue(int index)
  {
    return values[index];
  }

  public int Count
  {
    get { return values.Count; }
  }

  public void SetValue(int index, T value)
  {
    values[index] = value;
  }

  public float Compare(int i, int j)
  {
    return values[i].CompareTo(values[j]);
  }

  // O(1):O(1)
  // Swaps two elements in the `values` List by their indices
  private void Swap(int i, int j)
  {
    T temp = values[i];
    values[i] = values[j];
    values[j] = temp;
  }

  // O(n):O(1)
  // Checks if the values are sorted
  public bool IsSorted()
  {
    for (int i = 1; i < values.Count; i++)
    {
      if (values[i].CompareTo(values[i - 1]) < 0)
      {
        return false;
      }
    }
    return true;
  }

  public IReadOnlyList<T> Values
  {
    get { return values.AsReadOnly(); }
  }

  // O(n):O(1)
  // Randomizes the order of the `values`
  public Sortable<T> Shuffle()
  {
    int n = values.Count;
    for (int i = n - 1; i > 0; i--)
    {
      int j = rng.Next(i + 1);
      Swap(i, j);
    }
    return this;
  }

  public Sortable<T> ShuffleGuaranteedNotSorted()
  {
    do
    {
      Shuffle();
    } while (IsSorted());
    return this;
  }

  // Printing the values in their current order
  public override string ToString()
  {
    return "{" + string.Join(", ", values) + "}";
  }

}