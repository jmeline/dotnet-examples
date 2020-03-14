using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace algorithms
{
    public class UnitTest1
    {
        public void Swap(int[] arr, int i1, int i2)
        {
            var value = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = value;
        }
        
        public int Partitioner(int[] arr, int low, int high)
        {
            /*
             * Take first element as pivot,
             * places the pivot at it's correct position
             */
            
            // first element is pivot (element placed at left position)
            var pivot = arr[low];

            var i = high;// index of the larger element

            for (var j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(arr[] j, low)};
                }
            }
            
            return 1;
        }
        public void QuickSort(int[] arr, int low, int high)
        {
            
            /* Partitioning schemes
             * Always pick first element as pivot. 
             * Always pick last element as pivot 
             * Pick a random element as pivot.
             * Pick median as pivot.
             */

            // pick the first element as pivot
            var index = Partitioner(arr, low, high);


        }
        [Fact]
        public void Test1()
        {
            var items = new [] {1, 9, 2, 8, 3, 7, 4, 6, 5};
            var items2 = new [] {1, 9, 2, 8, 3, 7, 4, 6, 5};
            var expectedItems = new [] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            
            QuickSort(items, 0, items.Length);
            Assert.Equal(items, expectedItems);
        }
    }
}
