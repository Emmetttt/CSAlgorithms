using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures;
using System.Collections.Generic;

namespace AlgorithmTests
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void SetUnionTest()
        {
            List<int> List1 = new List<int> { 1, -4, 5, 7, 2, 3, -7 };
            List<int> List2 = new List<int> { 1, -3, 2, 3, 7, -8, -7 };
            Set<int> Set1 = new Set<int>(List1);
            Set<int> Set2 = new Set<int>(List2);

            List<int> exp = new List<int> { -8, -7, -4, -3, 1, 2, 3, 5, 7 };
            Set<int> Result = Set1.Union(Set2);

            CollectionAssert.AreEqual(exp, Result.Show());
        }
        [TestMethod]
        public void SetIntersectionTest()
        {
            List<int> List1 = new List<int> { 1, -4, 5, 7, 2, 3, -7 };
            List<int> List2 = new List<int> { 1, -3, 2, 3, 7, -8, -7 };
            Set<int> Set1 = new Set<int>(List1);
            Set<int> Set2 = new Set<int>(List2);

            List<int> exp = new List<int> { -7, 1, 2, 3, 7 };
            Set<int> Result = Set1.Intersection(Set2);

            CollectionAssert.AreEqual(exp, Result.Show());
        }
        [TestMethod]
        public void SetDifferenceTest()
        {
            List<int> List1 = new List<int> { 1, -4, 5, 7, 2, 3, -7 };
            List<int> List2 = new List<int> { 1, -3, 2, 3, 7, -8, -7 };
            Set<int> Set1 = new Set<int>(List1);
            Set<int> Set2 = new Set<int>(List2);

            List<int> exp = new List<int> { -4, 5 };
            Set<int> Result = Set1.Difference(Set2);

            CollectionAssert.AreEqual(exp, Result.Show());
        }
        [TestMethod]
        public void SetSymmetricDifferenceTest()
        {
            List<int> List1 = new List<int> { 1, -4, 5, 7, 2, 3, -7 };
            List<int> List2 = new List<int> { 1, -3, 2, 3, 7, -8, -7 };
            Set<int> Set1 = new Set<int>(List1);
            Set<int> Set2 = new Set<int>(List2);

            List<int> exp = new List<int> { -8, -4, -3, 5 };
            Set<int> Result = Set1.SymmetricDifference(Set2);

            CollectionAssert.AreEqual(exp, Result.Show());
        }
    }
}
