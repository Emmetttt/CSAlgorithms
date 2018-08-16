using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures;

namespace AlgorithmTests
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BTAddToTree()
        {
            BinaryTree tree = new BinaryTree();
            tree.Add(5);
            Assert.AreEqual("5", tree.Print());

            tree.Add(4);
            Assert.AreEqual("45", tree.Print());

            tree.Add(2);
            Assert.AreEqual("245", tree.Print());

            tree.Add(1);
            Assert.AreEqual("1245", tree.Print());

            tree.Add(6);
            Assert.AreEqual("12456", tree.Print());

            tree.Add(9);
            tree.Add(2);
            tree.Add(5);
            tree.Add(7);
            Assert.AreEqual("122455679", tree.Print());
        }

        [TestMethod]
        public void BTRemoveFromTree()
        {
            BinaryTree tree = createTree();
            Assert.AreEqual("12345678101010111212131415", tree.Print());

            tree.Remove(11);
            Assert.AreEqual("123456781010101212131415", tree.Print());

            tree = createTree();
            tree.Remove(13);
            Assert.AreEqual("123456781010101112121415", tree.Print());

            tree = createTree();
            tree.Remove(6);
            Assert.AreEqual("1234578101010111212131415", tree.Print());

            tree = createTree();
            tree.Remove(1);
            Assert.AreEqual("2345678101010111212131415", tree.Print());
        }

        public BinaryTree createTree()
        {
            BinaryTree tree = new BinaryTree();
            tree.Add(10);
            // Left side
            tree.Add(6);
            tree.Add(8);
            tree.Add(7);
            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(3);
            tree.Add(1);
            // Right side
            tree.Add(12);
            tree.Add(11);
            tree.Add(10);
            tree.Add(10);
            tree.Add(13);
            tree.Add(12);
            tree.Add(14);
            tree.Add(15);

            return tree;
        }
        [TestMethod]
        public void BTPrintWhile()
        {
            BinaryTree tree = createTree();
            Assert.AreEqual("12345678101010111212131415", tree.PrintWhile());

        }
        [TestMethod]
        public void BTContains()
        {
            BinaryTree tree = createTree();
            Assert.AreEqual(true, tree.Contains(3));
            Assert.AreEqual(true, tree.Contains(15));
            Assert.AreEqual(true, tree.Contains(10));
            Assert.AreNotEqual(true, tree.Contains(22));

        }
    }
}
