// Сортировка числовых и текстовых значений
// методами сортировки выбором (Selection sort)
// и пирамидальной сортировкой (Heapsort) 

using System;
using System.Collections.Generic;

namespace program_tech_labs_cw.Models;

public partial class FirstTaskModel
{
    public static List<double> SelectionSort(List<double> array)
    {
        ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Trace, $"Double selection sort started at {DateTime.Now:HH:mm:ss.fff}"); // TODO: edit
        int arrayLength = array.Count;

        for (int i = 0; i < arrayLength - 1; i++)
        {
            var minValueIndex = i;

            for (int j = i + 1; j < arrayLength; j++)
            {
                if (array[j] < array[minValueIndex])
                {
                    minValueIndex = j;
                }
            }

            double tempVar = array[minValueIndex];
            array[minValueIndex] = array[i];
            array[i] = tempVar;
        }
        ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Trace, $"Double selection sort ended at {DateTime.Now:HH:mm:ss.fff}"); // TODO: edit
        return array;
    }

    public static List<string> SelectionSort(List<string> array)
    {
        int arrayLength = array.Count;
        for(int i = 0; i < arrayLength - 1; i++)
        {
            int minIndex = i;
            string minStr = array[i];
         
            for(int j = i + 1; j < arrayLength; j++) 
            {
                if (string.Compare(array[j], minStr, StringComparison.Ordinal) != 0) 
                {
                    minStr = array[j];
                    minIndex = j;
                }
            }
            
            if (minIndex != i)
            {
                string temp = array[minIndex];
                array[minIndex] = array[i]; 
                array[i] = temp;
            }
        }

        return array;
    }
    
    public static List<double> HeapSort(List<double> array)
    {
        int arrayLength = array.Count;
        if (arrayLength <= 1)
            return array;

        for (int i = arrayLength / 2 - 1; i >= 0; i--)
        {
            Heapify(array, arrayLength, i);
        }

        for (int i = arrayLength - 1; i >= 0; i--)
        {
            var tempVar = array[0];
            array[0] = array[i];
            array[i] = tempVar;

            Heapify(array, i, 0);
        }

        return array;
    }
    
    public static List<string> HeapSort(List<string> array)
    {
        int arrayLength = array.Count;
        for (int i = 0; i < arrayLength; i++)
        {
            HeapForm(array[i]);
        }
    	
        MainHeapSort();
        _heapSortIndex = -1;
        _heap = new string[1000];
        return _sorted;
    }
}

public partial class FirstTaskModel
{
    private static int _heapSortIndex = -1;
    private static string[] _heap = new string[1000];
    private static List<string> _sorted = new();

    private static void Heapify(IList<double> array, int size, int index)
    {
        var largestIndex = index;
        var leftChild = 2 * index + 1;
        var rightChild = 2 * index + 2;

        if (leftChild < size && array[leftChild] > array[largestIndex])
        {
            largestIndex = leftChild;
        }

        if (rightChild < size && array[rightChild] > array[largestIndex])
        {
            largestIndex = rightChild;
        }

        if (largestIndex != index)
        {
            var tempVar = array[index];
            array[index] = array[largestIndex];
            array[largestIndex] = tempVar;

            Heapify(array, size, largestIndex);
        }
    }
    
    private static void HeapForm(string k)
    {
        _heapSortIndex++;

        _heap[_heapSortIndex] = k;

        int child = _heapSortIndex;

        string tmp;

        int index = _heapSortIndex / 2;

        // Iterative heapiFy
        while (index >= 0)
        {

            // Just swapping if the element
            // is smaller than already
            // stored element
            if (string.Compare(_heap[index], _heap[child], StringComparison.Ordinal) > 0)
            {

                // Swapping the current index
                // with its child
                tmp = _heap[index];
                _heap[index] = _heap[child];
                _heap[child] = tmp;
                child = index;
                
                index /= 2;
            }
            else
            {
                break;
            }
        }
    }
    
    private static void MainHeapSort()
    {
        int left1, right1;

        while (_heapSortIndex >= 0)
        {
            string k = _heap[0];
            
            _sorted.Add(k);
    		
            _heap[0] = _heap[_heapSortIndex];
    		
            _heapSortIndex -= 1;

            int index = 0;

            int length = _heapSortIndex;
    		
            left1 = 1;

            right1 = left1 + 1;

            while (left1 <= length)
            {
                if (string.Compare(_heap[index], _heap[left1], StringComparison.Ordinal) <= 0 &&
                    string.Compare(_heap[index], _heap[right1], StringComparison.Ordinal) <= 0)
                {
                    break;
                }
    			
                string temp;
                if (string.Compare(_heap[left1], _heap[right1], StringComparison.Ordinal) < 0)
                {
                    temp = _heap[index];
                    _heap[index] = _heap[left1];
                    _heap[left1] = temp;
                    index = left1;
                }
                else
                {
                    temp = _heap[index];
                    _heap[index] = _heap[right1];
                    _heap[right1] = temp;
                    index = right1;
                }
    			
                left1 = 2 * left1;
                right1 = left1 + 1;
            }
        }
    }
}