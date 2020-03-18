namespace algorithms.Algorithms.Sorting.QuickSort
{
    public class QuickSortImpl
    {
        private readonly IPartitioner _partitionImpl;

        public QuickSortImpl(IPartitioner partitionImpl)
        {
            _partitionImpl = partitionImpl;
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
            if (low < high)
            {
                var index = _partitionImpl.Partition(arr, low, high);
                QuickSort(arr, low, index);
                QuickSort(arr, index + 1, high);
            }
        }
    }
}