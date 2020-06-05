using System;
using System.Diagnostics;
using algorithms.Algorithms.Sorting.QuickSort;
using Algorithms.Utils;
using Xunit;

namespace Algorithms.AlgorithmTests.Sorting.QuickSort
{
    public class QuickSort
    {
        [Fact]
        public void TestPivotAsFirstElement()
        {
            var test = RandomNumberGenerator.GenerateRandomIntArray(100000);
            Stopwatch stopwatch = Stopwatch.StartNew();
            var sorter = new QuickSortImpl(new PartitionerStart());
            sorter.QuickSort(test, 0, test.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("elapsedTime: " + stopwatch.ElapsedMilliseconds);

        }
    }
}
