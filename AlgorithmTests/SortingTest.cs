using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures;

namespace AlgorithmTests
{
    [TestClass]
    public class SortingTest
    {
        [TestMethod]
        public void SortBubbleTest()
        {
            int[] arr = { 6, 5, 7, 2, 5, 3, 4, 3, 2, 1, 5, 3, 22, 10 };
            int[] expected = { 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 6, 7, 10, 22 };
            Sorting.BubbleSort(arr);

            CollectionAssert.AreEqual(expected, arr);
        }
        [TestMethod]
        public void SortInsertionTest()
        {
            int[] arr = { 6, 5, 7, 2, 5, 3, 4, 3, 2, 1, 5, 3, 22, 10 };
            int[] expected = { 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 6, 7, 10, 22 };
            Sorting.InsertionSort(arr);

            CollectionAssert.AreEqual(expected, arr);
        }
        [TestMethod]
        public void SortSelectionTest()
        {
            int[] arr = { 6, 5, 7, 2, 5, 3, 4, 3, 2, 1, 5, 3, 22, 10 };
            int[] expected = { 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 6, 7, 10, 22 };
            Sorting.SelectionSort(arr);

            CollectionAssert.AreEqual(expected, arr);
        }
        [TestMethod]
        public void SortMergeTest()
        {
            int[] arr = { 6, 5, 7, 2, 5, 3, 4, 3, 2, 1, 5, 3, 22, 10 };
            int[] expected = { 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 6, 7, 10, 22 };
            Sorting.MergeSort(arr);

            CollectionAssert.AreEqual(expected, arr);
        }
        [TestMethod]
        public void SortQuickTest()
        {
            int[] arr = { 6, 5, 7, 2, 5, 3, 4, 3, 2, 1, 5, 3, 22, 10 };
            int[] expected = { 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 6, 7, 10, 22 };
            Sorting.QuickSort(arr);

            CollectionAssert.AreEqual(expected, arr);
        }
        [TestMethod]
        public void SortHeapTest()
        {
            int[] arr = { 6, 5, 7, 2, 5, 3, 4, 3, 2, 1, 5, 3, 22, 10 };
            int[] expected = { 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 6, 7, 10, 22 };
            Sorting.HeapSort(arr);

            CollectionAssert.AreEqual(expected, arr);
        }
    }
}