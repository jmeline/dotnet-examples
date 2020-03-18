using algorithms.Algorithms.Sorting.QuickSort;
using Xunit;

namespace Algorithms.AlgorithmTests.Sorting.QuickSort
{
    public class QuickSort
    {
        [Fact]
        public void TestPivotAsFirstElement()
        {
            var test = new[] {20, 80, 30, 90, 10, 50, 70};
            var sorter = new QuickSortImpl(new PartitionerStart());
            sorter.QuickSort(test, 0, test.Length - 1);
            Assert.Equal(test, new []{ 10, 20, 30, 50, 70, 80, 90 });
        }
    }
}
