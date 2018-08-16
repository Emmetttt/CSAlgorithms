using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures;

namespace AlgorithmTests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void StackCreate()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(5);
            stack.Push(13);
            int ExpPop = 13;
            Assert.AreEqual(stack.Pop(), ExpPop);

            ExpPop = 5;
            Assert.AreEqual(stack.Pop(), ExpPop);

            int ExpPeep = 1;
            Assert.AreEqual(stack.Peek(), ExpPeep);

            ExpPeep = 1;
            Assert.AreEqual(stack.Peek(), ExpPeep);

            ExpPeep = 1;
            Assert.AreEqual(stack.Peek(), ExpPeep);
        }
        [TestMethod]
        public void StackPostfix()
        {
            string postfix = "567*+1-";
            int ans = 46;

            Assert.AreEqual(ans, Stack<int>.Postfix(postfix));

        }
    }
}
