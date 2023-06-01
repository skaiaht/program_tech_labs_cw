// Сортировка числовых и текстовых значений
// методами сортировки выбором (Selection sort)
// и пирамидальной сортировкой (Heap sort) 

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace program_tech_labs_cw.Models;

public static partial class FirstTaskModel
{
    public static ObservableCollection<DoubleItem> SelectionSort(ObservableCollection<DoubleItem> array)
    {
        int moveActionCounter = 0;
        int arrayLength = array.Count;

        for (int i = 0; i < arrayLength - 1; i++)
        {
            var minValueIndex = i;

            for (int j = i + 1; j < arrayLength; j++)
            {
                if (array[j].Value < array[minValueIndex].Value)
                {
                    minValueIndex = j;
                }
            }

            DoubleItem tempVar = array[minValueIndex];
            array[minValueIndex] = array[i];
            moveActionCounter++;
            array[i] = tempVar;
            moveActionCounter++;
        }
        
        ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items move action count: {moveActionCounter} times.");
        return array;
    }

    public static ObservableCollection<StringItem> SelectionSort(ObservableCollection<StringItem> collection)
    {
        int moveActionCounter = 0;
        int n = collection.Count;

        // One by one move the boundary of the unsorted subarray
        for (int i = 0; i < n - 1; i++)
        {
            // Find the minimum element in the unsorted part of the array
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (string.Compare(collection[j].Value, collection[minIndex].Value) < 0)
                {
                    minIndex = j;
                }
            }

            // Swap the found minimum element with the first element
            StringItem temp = collection[minIndex];
            collection[minIndex] = collection[i];
            moveActionCounter++;
            collection[i] = temp;
            moveActionCounter++;
        }

        ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items move action count: {moveActionCounter} times.");
        return collection;
    }
    
    public static ObservableCollection<DoubleItem> HeapSort(ObservableCollection<DoubleItem> array)
    {
        int moveActionCounter = 0;
        int arrayLength = array.Count;
        if (arrayLength <= 1)
            return array;

        for (int i = arrayLength / 2 - 1; i >= 0; i--)
        {
            HeapifyDoubleItems(array, arrayLength, i, moveActionCounter);
        }

        for (int i = arrayLength - 1; i >= 0; i--)
        {
            var tempVar = array[0];
            array[0] = array[i];
            moveActionCounter++;
            array[i] = tempVar;
            moveActionCounter++;

            HeapifyDoubleItems(array, i, 0, moveActionCounter);
        }

        ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items move action count: {moveActionCounter} times.");
        return array;
    }

    public static ObservableCollection<StringItem> HeapSort(ObservableCollection<StringItem> collection)
    {
        int moveActionCounter = 0;
        int n = collection.Count;

        // Build heap (rearrange array)
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            HeapifyStringItems(collection, n, i, moveActionCounter);
        }

        // One by one extract an element from heap
        for (int i = n - 1; i >= 0; i--)
        {
            // Move current root to end
            StringItem temp = collection[0];
            collection[0] = collection[i];
            moveActionCounter++;
            collection[i] = temp;
            moveActionCounter++;

            // call max heapify on the reduced heap
            HeapifyStringItems(collection, i, 0, moveActionCounter);
        }

        ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items move action count: {moveActionCounter} times.");
        return collection;
    }
}

public static partial class FirstTaskModel
{
    private static void HeapifyStringItems(ObservableCollection<StringItem> collection, int n, int i, int moveActionCounter)
    {
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // left = 2*i + 1
        int right = 2 * i + 2; // right = 2*i + 2

        // If left child is larger than root
        if (left < n && string.Compare(collection[left].Value, collection[largest].Value) > 0)
        {
            largest = left;
        }

        // If right child is larger than largest so far
        if (right < n && string.Compare(collection[right].Value, collection[largest].Value) > 0)
        {
            largest = right;
        }

        // If largest is not root
        if (largest != i)
        {
            StringItem swap = collection[i];
            collection[i] = collection[largest];
            moveActionCounter++;
            collection[largest] = swap;
            moveActionCounter++;

            // Recursively heapify the affected sub-tree
            HeapifyStringItems(collection, n, largest, moveActionCounter);
        }
    }
    
    private static void HeapifyDoubleItems(ObservableCollection<DoubleItem> array, int size, int index, int moveActionCounter)
    {
        var largestIndex = index;
        var leftChild = 2 * index + 1;
        var rightChild = 2 * index + 2;

        if (leftChild < size && array[leftChild].Value > array[largestIndex].Value)
        {
            largestIndex = leftChild;
        }

        if (rightChild < size && array[rightChild].Value > array[largestIndex].Value)
        {
            largestIndex = rightChild;
        }

        if (largestIndex != index)
        {
            var tempVar = array[index];
            array[index] = array[largestIndex];
            moveActionCounter++;
            array[largestIndex] = tempVar;
            moveActionCounter++;

            HeapifyDoubleItems(array, size, largestIndex, moveActionCounter);
        }
    }
}

public enum SortType
{
    HeapSort,
    SelectionSort
}

public enum DataType
{
    Double,
    String
}

public class Worker
{
    private IEnumerable<IDataItem<string>>? StringItems { get; set; }
    private IEnumerable<IDataItem<double>>? DoubleItems { get; set; }
    private DataType DataType { get; }
    public Worker(IEnumerable<IDataItem<string>> stringItems, DataType dataType)
    {
        StringItems = stringItems;
        DataType = dataType;
    }
    
    public Worker(IEnumerable<IDataItem<double>> doubleItems, DataType dataType)
    {
        DoubleItems = doubleItems;
        DataType = dataType;
    }

    public void Sort(SortType sortType)
    {
        try
        {
            Stopwatch watch = Stopwatch.StartNew();
            switch (sortType)
            {
                case SortType.HeapSort:
                    switch (DataType)
                    {
                        case DataType.Double:
                            DoubleItems = FirstTaskModel.HeapSort((ObservableCollection<DoubleItem>)DoubleItems! ??
                                                                  throw new InvalidOperationException());
                            break;
                        case DataType.String:
                            StringItems = FirstTaskModel.HeapSort((ObservableCollection<StringItem>)StringItems! ??
                                                                  throw new InvalidOperationException());
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case SortType.SelectionSort:
                    switch (DataType)
                    {
                        case DataType.Double:
                            DoubleItems = FirstTaskModel.SelectionSort((ObservableCollection<DoubleItem>)DoubleItems! ??
                                                                       throw new InvalidOperationException());
                            break;
                        case DataType.String:
                            StringItems = FirstTaskModel.SelectionSort((ObservableCollection<StringItem>)StringItems! ??
                                                                       throw new InvalidOperationException());
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                default:
                    watch.Stop();
                    break;
            }
            watch.Stop();
            ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Time elapsed: {watch.ElapsedMilliseconds} milliseconds.");
        
            int itemCounter;
            itemCounter = 0;
            if (DoubleItems != null)
                foreach (var item in DoubleItems)
                {
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Element #{itemCounter}: {item.Value}.");
                    itemCounter++;
                }
            itemCounter = 0;
            if (StringItems != null)
                foreach (var item in StringItems)
                {
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Element #{itemCounter}: {item.Value}.");
                    itemCounter++;
                }
        }
        catch (Exception e)
        {
            ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Error, $"SORT FAILED: {e}");
        }
    }
}