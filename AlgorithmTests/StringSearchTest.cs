using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsAndDataStructures;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTests
{
    [TestClass]
    public class StringSearchTest
    {
        string test = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        string find1 = "Lorem";
        StringSearchMatch exp1 = new StringSearchMatch(0, 5);
        string find2 = "Letraset";
        StringSearchMatch exp2 = new StringSearchMatch(443-24, 8);

        [TestMethod]
        public void SSNaive()
        {
            NaiveStringSearch Naive = new NaiveStringSearch();
            IEnumerable<ISearchMatch> result1 = Naive.Search(find1, test);
            Assert.AreEqual(exp1.Length, result1.First<ISearchMatch>().Length);
            Assert.AreEqual(exp1.Start, result1.First<ISearchMatch>().Start);

            IEnumerable<ISearchMatch> result2 = Naive.Search(find2, test);
            Assert.AreEqual(exp2.Length, result2.First<ISearchMatch>().Length);
            Assert.AreEqual(exp2.Start, result2.First<ISearchMatch>().Start);
        }
        [TestMethod]
        public void SSBoyerMooreHorspool()
        {
            BoyerMooreHorspool BMH = new BoyerMooreHorspool();
            IEnumerable<ISearchMatch> result1 = BMH.Search(find1, test);
            Assert.AreEqual(exp1.Length, result1.First<ISearchMatch>().Length);
            Assert.AreEqual(exp1.Start, result1.First<ISearchMatch>().Start);

            IEnumerable<ISearchMatch> result2 = BMH.Search(find2, test);
            Assert.AreEqual(exp2.Length, result2.First<ISearchMatch>().Length);
            Assert.AreEqual(exp2.Start, result2.First<ISearchMatch>().Start);
        }
    }
}
