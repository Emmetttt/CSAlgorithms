using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsAndDataStructures
{
    public class NaiveStringSearch : IStringSearchAlgorithm
    {
        public IEnumerable<ISearchMatch> Search(string toFind, string toSearch)
        {
            for (int i = 0; i < toSearch.Length; i++)
            {
                int matchCount = 0;
                while (toSearch[i + matchCount] == toFind[matchCount])
                {
                    matchCount++;
                    if (toFind.Length == matchCount)
                    {
                        yield return new StringSearchMatch(i, matchCount);

                        i += matchCount - 1;
                        break;
                    }
                }
            }
        }
    }
    public class BoyerMooreHorspool : IStringSearchAlgorithm
    {
        public Dictionary<int, int> BadMatchTable(string pattern)
        {
            int _defaultValue = pattern.Length;
            Dictionary<int, int> _distances = new Dictionary<int, int>();

            for (int i = 0; i < pattern.Length - 1; i++)
            {
                _distances[pattern[i]] = pattern.Length - i - 1;
            }

            return _distances;
        }
        public IEnumerable<ISearchMatch> Search(string toFind, string toSearch)
        {
            // Stage 1: Preprocess the string to build a table that contains the
            //          length to shift when a bad match occurs
            //          a. Store the length of the search string as default shift length
            //          b. For-each char in the search string to set shift index
            // Stage 2: String is searched backwards using the bad match table
            Dictionary<int, int> Distances = BadMatchTable(toFind);
            int i = 0;
            int skip = 0;
            while (i < toSearch.Length - toFind.Length)
            {
                int j = toFind.Length - 1;
                int strptr = i;
                while (toSearch[strptr] == toFind[j])
                {
                    j--;
                    strptr--;
                    if (j == 0)
                    {
                        yield return new StringSearchMatch(strptr, toFind.Length);
                        break;
                    }
                }
                if (Distances.TryGetValue(toSearch[i], out skip))
                {
                    i += Distances[toSearch[i]];
                }
                else
                {
                    i += toFind.Length - 1;
                }
            }

        }
    }
    public class StringSearchMatch : ISearchMatch
    {
        public StringSearchMatch(int start, int length)
        {
            Start = start;
            Length = length;
        }
        public int Start
        {
            get;
            private set;
        }
        public int Length
        {
            get;
            private set;
        }
    }
    public interface IStringSearchAlgorithm
    {
        IEnumerable<ISearchMatch> Search(string toFind, string toSearch);
    }

    public interface ISearchMatch
    {
        int Start { get; }
        int Length { get; }
    }
}
