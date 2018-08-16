using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures;

namespace AlgorithmTests
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void HTNaiveHash()
        {
            
            string test = "foo";
            Assert.AreEqual(324, HashTable<string, string>.NaiveHash(test));
        }
        //[TestMethod]
        //public void FoldHash()
        //{

        //    string test = "lorem ipsum dolor";
        //    Assert.AreEqual(1706390818, HashTable<string, string>.FoldHash(test));
        //}

        //[TestMethod]
        //public void Insert()
        //{
        //    HashTable<string, string> table = new HashTable<string, string>(10);
        //    string key = "Emmett";
        //    string value = "Emmett Moore";

        //    table.Insert(key, value);

        //}
    }
}
