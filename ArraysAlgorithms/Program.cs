using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] originalList = new char[] { 'A', 'B', 'C', 'D'};
            Stack<char> currentList = new Stack<char>();
            List<char[]> listOfSubsets = new List<char[]>();

            char[] originalList2 = new char[] { 'A', 'B', 'D', 'C'};
            Stack<char> currentList2 = new Stack<char>();
            List<char[]> listOfSubsets2 = new List<char[]>();

            var resultSubList = new List<char>();
            var resultSubList2 = new List<char>();

            var result = BuildListOfSubsets(originalList, listOfSubsets, 0, currentList);
            var  result2 = BuildListOfSubsets(originalList2, listOfSubsets2, 0, currentList);

            var equalStrings = FindEqualStrings(result, result2);

            var minStrings = FindMinStrings();

        }

        private static List<char[]> BuildListOfSubsets(char[] originalList, List<char[]> listOfSubsets, int currentLevel, Stack<char> currentList)
        {
            var resultSubList = new List<char>();
            foreach (var v in currentList)
            {
                Console.Write(v + " ");
                resultSubList.Add(v);
            }
            if(resultSubList.Count > 0)
            {
                listOfSubsets.Add(resultSubList.ToArray<char>());
            }

            Console.WriteLine();

            for (int ix = currentLevel; ix < originalList.Length; ix++)
            {
                currentList.Push(originalList[ix]);
                BuildListOfSubsets(originalList, listOfSubsets, ix + 1, currentList);
                currentList.Pop();
            }

            return listOfSubsets;
        }

        private static List<char[]> FindEqualStrings(List<char[]> result, List<char[]> result2)
        {
            var equalStrings = new List<char[]>();
            for(var i=0; i<result.Count; i++)
            {
                for(var j = 0; j < result2.Count; j++)
                {
                    if(result[i] == result2[j])
                    {
                        equalStrings.Add(result[i]);
                        break;
                    }
                }
            }

            return equalStrings;
        }

        private char[] FindMinStrings()
        {
            //Find Min
            return new char[];
        }
    }
}
