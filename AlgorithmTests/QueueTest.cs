using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures;

namespace AlgorithmTests
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void QCreateQueueLL()
        {
            QueueLL<int> queue = new QueueLL<int>();

            queue.Enqueue(1);
            queue.Enqueue(5);
            queue.Enqueue(13);
            int ExpPop = 1;
            Assert.AreEqual(ExpPop, queue.Dequeue());

            ExpPop = 5;
            Assert.AreEqual(ExpPop, queue.Dequeue());
        }
        [TestMethod]
        public void QCreateQueueArr()
        {
            QueueArr<int> queue = new QueueArr<int>();

            queue.Enqueue(1);
            queue.Enqueue(5);
            queue.Enqueue(13);
            int ExpPop = 1;
            Assert.AreEqual(ExpPop, queue.Dequeue());

            ExpPop = 5;
            Assert.AreEqual(ExpPop, queue.Dequeue());

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);
            queue.Enqueue(14);
            queue.Enqueue(15);

            ExpPop = 13;
            Assert.AreEqual(ExpPop, queue.Dequeue());

            ExpPop = 1;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 2;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 3;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 4;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 5;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 6;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 7;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 8;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 9;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 10;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 11;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 12;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 13;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 14;
            Assert.AreEqual(ExpPop, queue.Dequeue());
            ExpPop = 15;
            Assert.AreEqual(ExpPop, queue.Dequeue());
        }
    }
}
