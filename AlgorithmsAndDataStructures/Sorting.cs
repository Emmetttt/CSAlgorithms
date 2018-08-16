using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public static class Sorting
    {
        // Linear - sorts the whole array at once, not reduced
        // Divide and conquer - Smaller objects sorted

        // Quantify - Number of comparisons
        //          - Number of swaps
        public static void Swap(int[] arr, int ptr1, int ptr2)
        {
            int temp = arr[ptr1];
            arr[ptr1] = arr[ptr2];
            arr[ptr2] = temp;
        }
        public static void Insert(int[] arr, int ptr1, int ptr2)
        {
            // insert number at position ptr2 into position ptr1
            int temp = arr[ptr2];
            int counter = ptr2;

            while (counter > ptr1)
            {
                // shift everything along one until ptr2 has been overwritten
                arr[counter] = arr[counter - 1];
                counter--;
            }

            arr[ptr1] = temp;
        }
        public static int[] BubbleSort(int[] arr)
        {
            // 1. Compare each array item to its right neighbour
            // 2. If right neighbour is smaller, swap right to left
            // 3. Repeat until a pass with no swaps occurs

            // Worst O(n^2)
            // Avg O(n^2)
            // Best O(n)

            // [6, 4, 1, 4]
            // [4, 1, 4, 6]
            // [1, 4, 4, 6]

            int index = 0;
            int compare = 1;
            int swaps = 0;

            do
            {
                index = 0;
                compare = 1;
                swaps = 0;
                while (index < arr.Length - 1) // O(N)
                {
                    if (arr[index] > arr[compare]) // O(N)
                    {
                        Swap(arr, index, compare);
                        swaps += 1;
                    }
                    index++;
                    compare = index + 1;
                }
            } while (swaps > 0);

            return arr;
        }

        public static int[] InsertionSort(int[] arr)
        {
            // Everything on the left is sorted
            // Everything on the right is sorted
            // Start on the array of 1, is already sorted
            // Increase to array of 2, sort that

            // Worst O(n^2)
            // Avg O(n^2)
            // Best O(n)

            // [5, 3, 4, 4, 8, 6, 7]
            // [3, 5|, 4, 4, 8, 6, 7] takes 5 and put it in the appropriate place
            // [3, 4, 5|, 4, 8, 6, 7] takes 4 and inserts
            // [3, 4, 4, 5|, 8, 6, 7] takes 4 and inserts
            // [3, 4, 4, 5, 8|, 6, 7] 8 already sorted, no action
            // [3, 4, 4, 5, 8|, 6, 7] insert 6
            // [3, 4, 4, 5, 6, 7, 8|] insert 7

            int index = 0;
            int partition = 1;
            int positionPtr = 0;

            while (index < arr.Length - 1)
            {
                positionPtr = 0;
                if (arr[index] > arr[partition]) // O(N)
                {
                    // Not sorted, largest is not last
                    while (arr[positionPtr] < arr[partition])
                    {
                        positionPtr++;
                    }
                    Insert(arr, positionPtr, partition); // O(N)
                }
                index++;
                partition++;
            }

            return arr;
        }

        public static int[] SelectionSort(int[] arr)
        {
            // Enumerate from left to right
            // Find the smallest item, move it to the first unsorted index
            // Repeat until the first unsorted index is the last in the array

            // Worst O(n^2)
            // Avg O(n^2) Typically better than bubble, worse than insertion
            // Best O(n^2) Lots of comparisons

            // [3, 8, 2, 1, 5, 4, 6, 7]
            // [1, 8, 2, 3, 5, 4, 6, 7] 1 found as smallest
            // [1, 2, 8, 3, 5, 4, 6, 7] Start at 8, find smallest which is 2
            // [1, 2, 3, 8, 5, 4, 6, 7] Start at 8, find smallest which is 3
            // [1, 2, 3, 4, 5, 8, 6, 7] Start at 8, find smallest which is 4
            // [1, 2, 3, 4, 5, 8, 6, 7] Start at 5 no smallest
            // [1, 2, 3, 4, 5, 6, 8, 7]
            // [1, 2, 3, 4, 5, 6, 7, 8]

            int start = 0;
            int count = 0;
            int smallest = arr[start];
            int smallestLoc = 0;

            while (start < arr.Length)
            {
                count = start+1;
                smallest = arr[start];
                smallestLoc = start;
                while (count < arr.Length)
                {
                    if (arr[count] < smallest)
                    {
                        smallest = arr[count];
                        smallestLoc = count;
                    }
                    count++;
                }
                if (smallest != arr[start])
                {
                    Swap(arr, smallestLoc, start);
                }
                start++;
            }

            return arr;
        }
        public static int[] MergeSort(int[] arr)
        {
            // Divide an conquer
            // Recursively split the array in half
            // When the array is in groups of 1, reconstruct in sort order

            // [3, 8, 2, 1, 5, 4, 6, 7]
            // [3, 8, 2, 1] [5, 4, 6, 7]
            // [3, 8]  [2, 1]  [5, 4]  [6, 7]
            // [3] [8] [2] [1] [5] [4] [6] [7]  Each single array is sorted

            // [3, 8] [1, 2] [4, 5] [6, 7]
            // [1, 2, 3, 8] [4, 5, 6, 7]
            // [1, 2, 3, 4, 5, 6, 7, 8]

            // Worst case O(n log n) parallelism possible due to splitting
            // Avg case O(n log n)
            // Best case O(n log n) has to split and reconstruct every time

            // split the array into two
            int size1 = arr.Length / 2;
            int size2 = (int)Math.Ceiling((double)arr.Length / 2);
            int[] Arr1 = new int[size1];
            int[] Arr2 = new int[size2];
            Array.Copy(arr, 0, Arr1, 0, Arr1.Length);
            Array.Copy(arr, size1, Arr2, 0, Arr2.Length);

            if (Arr1.Length > 2)
            {
                MergeSort(Arr1);
            }
            else if (Arr1.Length == 2)
            {
                if (Arr1[0] > Arr1[1])
                {
                    Swap(Arr1, 0, 1);
                }
            }
            if (Arr2.Length > 2)
            {
                MergeSort(Arr2);
            }
            else if (Arr2.Length == 2)
            {
                if (Arr2[0] > Arr2[1])
                {
                    Swap(Arr2, 0, 1);
                }
            }
            Merge(arr, Arr1, Arr2);
            return arr;
        }
        public static int[] Merge(int[] Target, int[] Arr1, int[] Arr2)
        {
            int Arr1ptr = 0;
            int Arr2ptr = 0;
            int counter = 0;
            while ((Arr1ptr < Arr1.Length) || (Arr2ptr < Arr2.Length))
            {
                if (Arr1ptr == Arr1.Length)
                {
                    // If all of Arr1 in target, push Arr2 in sequential order
                    Target[counter] = Arr2[Arr2ptr];
                    counter++;
                    Arr2ptr++;
                }
                else if (Arr2ptr == Arr2.Length)
                {
                    Target[counter] = Arr1[Arr1ptr];
                    counter++;
                    Arr1ptr++;
                }
                else if (Arr1[Arr1ptr] < Arr2[Arr2ptr])
                {
                    Target[counter] = Arr1[Arr1ptr];
                    counter++;
                    Arr1ptr++;
                }
                else
                {
                    Target[counter] = Arr2[Arr2ptr];
                    counter++;
                    Arr2ptr++;
                }
            }
            return Target;
        }
        public static int Partition(int[] arr, int left, int right)
        {
            // Returns index of the pivots new position
            // Increase left until find a number greater than pivot
            // Increase right until find number less than pivot
            // Swap the values and keep going until left = right
            int pivot = right;
            right--;
            while (right+1 > left)
            {
                if (arr[left] <= arr[pivot])
                {
                    left++;
                }
                else if (arr[right] > arr[pivot])
                {
                    right--;
                }
                else
                {
                    Swap(arr, left, right);
                    left++;
                    right--;
                }
            }

            Swap(arr, pivot, left); // left ends up overlapping with right

            return left; //Position of pivot
        }
        public static void QuickSort(int[] arr, int low=0, int high=0)
        {
            // Divide and conquer
            // Pick a pivot value and partition the array
            // All the values smaller than the pivot value is place to the left
            // All the values larger than the pivot value is placed to the right
            // Pivot and partition on the left and right partitions
            // Repeat until sorted

            // [3, 8, 2, 1, 5, 4, 6, 7] Pivot on 5
            // [3, 4, 2, 1, 5, 8, 6, 7] 4 and 8 swapped - we know 5 is in the right spot
            // [3, 4, 2, 1, 5, 8, 6, 7] Pivot on 2
            // [1, 2, 3, 4, 5, 8, 6, 7] Everything to the left of 2 is smaller
            // [1, 2, 3, 4, 5, 8, 6, 7] Pivot on 3, already sorted.
            // [1, 2, 3, 4, 5, 6, 7, 8] Pivot on 7, 

            // Worst case O(n^2) pathologically worst case
            // Avg case O(n log n)
            // Best case O(n log n)
            // Space required is lower than MergeSort
            if (high == 0) high = arr.Length - 1;
            int pivot = 0;


            pivot = Partition(arr, low, high);
            if (low < pivot - 1)
            {
                QuickSort(arr, low, pivot - 1);
            }
            if (high > pivot + 1)
            {
                QuickSort(arr, pivot + 1, high);
            }
        }
        public static void HeapSort(int[] arr)
        {
            // Build a heap out of the data
            // Repeatedly remove the largest element from the heap into the array

            // Building heap
            // node K, left child 2K+1, right child 2K+2
            int counter = arr.Length - 1;
            BuildMaxHeap(arr);
            while (counter > 0)
            {
                //replace top and bottom, remove bottom
                Swap(arr, 0, counter);
                counter--;
                ReHeapify(arr, 0, counter);
            }
        }
        public static void BuildMaxHeap(int[] arr)
        {
            int length = arr.Length;
            int row = 1;
            length--;

            while ( length - (row*2) > 0)
            {
                length = length - (row*2);
                row *= 2;
            }
            for (int i = 1; i <= length; i++)
            {
                Heapify(arr, arr.Length - i);
            }
        }
        public static void Heapify(int[] arr, int pos)
        {
            int left = (pos+1) % 2; // if 0, then is left, if 1, then right
            int parent = (left == 0) ? (int) 0.5 * (pos - 1) : (int) 0.5 * (pos - 2);

            if (left == 0)
            {
                parent = (int)(pos - 1) / 2;
            }
            else
            {
                parent = (int)(pos - 2) / 2;
            }

            if (arr[parent] < arr[pos])
            {
                Swap(arr, pos, parent);
            }

            if (parent != 0)
            {
                Heapify(arr, parent);
            }
        }
        public static void ReHeapify(int[] arr, int pos, int sizeOf)
        {
            int left = 2 * pos + 1;
            int leftVal = 0;
            if (left > sizeOf)
                left = 0;
            else
                leftVal = arr[left];

            int right = 2 * pos + 2;
            int rightVal = 0; 
            if (right > sizeOf)
                right = 0;
            else
                rightVal = arr[right];

            if (leftVal >= rightVal && leftVal > arr[pos])
            {
                Swap(arr, left, pos);
                ReHeapify(arr, left, sizeOf);
            }
            else if (rightVal > leftVal && rightVal > arr[pos])
            {
                Swap(arr, right, pos);
                ReHeapify(arr, right, sizeOf);
            }
        }
    }
}
