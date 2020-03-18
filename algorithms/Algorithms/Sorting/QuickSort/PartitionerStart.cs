namespace algorithms.Algorithms.Sorting.QuickSort
{
    public class PartitionerStart : IPartitioner
    {
        // Modified from https://www.youtube.com/watch?v=COk73cpQbFQ
        private void Swap(int[] arr, int t1, int t2)
        {
            var value = arr[t1];
            arr[t1] = arr[t2];
            arr[t2] = value;
        }
        
        public int Partition(int[] arr, int low, int high)
        {
            /*
             * Take first element as pivot,
             * places the pivot at it's correct position
             */
            
            // first element is selected as the pivot 
            var pivot = arr[low];
            var pIndex = high; // index of the highest element

            // reorder the array so that all elements
            // with values less than the pivot come before the pivot, while
            // all elements with values greater than the pivot come after it
            for (var j = high; j > low ; j--)
            {
                if (arr[j] >= pivot)
                {
                    Swap(arr , j, pIndex);
                    --pIndex;
                }
            }
            Swap(arr, pIndex, low);
            return pIndex;
        }
    }
}