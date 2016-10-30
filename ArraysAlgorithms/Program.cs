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
            char[] originalList = new char[] { 'H', 'A', 'R', 'R', 'Y'};
            Stack<char> currentList = new Stack<char>();
            List<char[]> listOfSubsets = new List<char[]>();

            char[] originalList2 = new char[] { 'S', 'A', 'L', 'L', 'Y'};
            Stack<char> currentList2 = new Stack<char>();
            List<char[]> listOfSubsets2 = new List<char[]>();

            var resultSubList = new List<char>();
            var resultSubList2 = new List<char>();

            Console.WriteLine("Children of String A:");
            var result = BuildListOfSubsets(originalList, listOfSubsets, 0, currentList);
          

            Console.WriteLine("Children of String B:");
            var  result2 = BuildListOfSubsets(originalList2, listOfSubsets2, 0, currentList);

            var equalStrings = FindEqualStrings(result, result2);

            var minStrings = FindMinStrings(equalStrings);

            Console.WriteLine("Max Shared Sub String: ");
            for(var c = minStrings.Count()-1; c>=0;c--)
            {
                Console.Write(minStrings[c]);
            }
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
                    if(result[i].CompairTwoCharArrays(result2[j]))
                    {
                        equalStrings.Add(result[i]);
                        break;
                    }
                }
            }

            return equalStrings;
        }

        private static char[] FindMinStrings(List<char[]> charArray)
        {
            var maxIndex = -1;
            var maxLength = 0;

            for(var c = 0; c<charArray.Count; c++)
            {
                if (charArray[c].Count() > maxLength)
                {
                    maxIndex = c;
                    maxLength = charArray[c].Count();
                }                    
            }

            return maxIndex != -1 ? charArray[maxIndex] : new char[0];
        }
    }
}
