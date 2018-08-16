using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures;

namespace AlgorithmTests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void LLAddToFrontUninit()
        {
            LinkedList LL = new LinkedList();
            LL.AddFirst(5);

            string expected = "5";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLAddToFrontInit()
        {
            LinkedList LL = new LinkedList(3);
            LL.AddFirst(5);

            string expected = "5, 3";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLAddToFrontLong()
        {
            LinkedList LL = new LinkedList(3);
            LL.AddFirst(5);
            LL.AddFirst(4);
            LL.AddFirst(3);
            LL.AddFirst(6);

            string expected = "6, 3, 4, 5, 3";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLAddToEndUninit()
        {
            LinkedList LL = new LinkedList();
            LL.AddEnd(5);

            string expected = "5";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLAddToEndInit()
        {
            LinkedList LL = new LinkedList(3);
            LL.AddEnd(5);

            string expected = "3, 5";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLAddToEndLong()
        {
            LinkedList LL = new LinkedList(3);
            LL.AddEnd(5);
            LL.AddEnd(3);
            LL.AddEnd(2);
            LL.AddEnd(2);
            LL.AddEnd(1);

            string expected = "3, 5, 3, 2, 2, 1";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLRemoveFromEndShort()
        {
            LinkedList LL = new LinkedList(3);
            LL.RemoveLast();

            string expected = "";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLRemoveFromEndLong()
        {
            LinkedList LL = new LinkedList(3);
            LL.AddEnd(5);
            LL.AddEnd(3);
            LL.AddEnd(2);
            LL.AddEnd(2);
            LL.AddEnd(1);
            LL.RemoveLast();

            string expected = "3, 5, 3, 2, 2";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLRemoveFromFrontLong()
        {
            LinkedList LL = new LinkedList(3);
            LL.AddEnd(5);
            LL.AddEnd(3);
            LL.AddEnd(2);
            LL.AddEnd(2);
            LL.AddEnd(1);
            LL.RemoveFront();

            string expected = "5, 3, 2, 2, 1";

            Assert.AreEqual(expected, LL.PrintList());
        }
        [TestMethod]
        public void LLRemoveFromFrontShort()
        {
            LinkedList LL = new LinkedList(3);
            LL.RemoveFront();

            string expected = "";

            Assert.AreEqual(expected, LL.PrintList());
        }

    }
}
