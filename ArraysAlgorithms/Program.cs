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
            char[] originalList = new char[] { 'B', 'A', 'N', 'A', 'N', 'A', 'S'};
            Stack<char> currentList = new Stack<char>();
            List<char[]> listOfSubsets = new List<char[]>();

            //char[] originalList2 = new char[] { 'S', 'A', 'L', 'L', 'Y'};
            //Stack<char> currentList2 = new Stack<char>();
            //List<char[]> listOfSubsets2 = new List<char[]>();

            //var resultSubList = new List<char>();
            //var resultSubList2 = new List<char>();

            //Console.WriteLine("Children of String A:");
            var result = BuildListOfSubsets(originalList, listOfSubsets, 0, currentList);            

            //Console.WriteLine("Children of String B:");
            //var  result2 = BuildListOfSubsets(originalList2, listOfSubsets2, 0, currentList);

            //var equalStrings = FindEqualStrings(result, result2);

            //var minStrings = FindMinStrings(equalStrings);

            //Console.WriteLine("Max Shared Sub String: ");
            //for(var c = minStrings.Count()-1; c>=0;c--)
            //{
            //    Console.Write(minStrings[c]);
            //}

            //var palindroms = FindAllPalindroms(result);

            //var permutations = FindAllPermutations(originalList, new List<char[]>(), 0, currentList);

            var charArray = new char[] { 'A','E','R'};
            Permutations(charArray, new List<char[]>(), 0, charArray.Count() - 1);
        }

        private static void Permutations(char[] charArray, List<char[]> result, int start, int end)
        {
            if (start == end)
                Console.WriteLine(charArray);
            for (var i = start; i< charArray.Count(); i++)
            {
                //Console.WriteLine(charArray[i]);
                Swap(charArray, start, i);
                Permutations(charArray, result, start+1, end);
                Swap(charArray, start, i);
            }
        }

        private static void Swap(char[] list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
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

        private static List<char[]> FindAllPermutations(char[] originalList, List<char[]> listOfSubsets, int currentLevel, Stack<char> currentList)
        {
            var resultSubList = new List<char>();

            foreach (var v in currentList)
            {
                Console.Write(v + " ");
                resultSubList.Add(v);
            }

            if (resultSubList.Count == originalList.Count())
            {
                listOfSubsets.Add(resultSubList.ToArray<char>());
            }

            Console.WriteLine();

            for (int ix = currentLevel; ix < originalList.Length; ix++)
            {
                currentList.Push(originalList[ix]);
                FindAllPermutations(originalList, listOfSubsets, ix + 1, currentList);
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

        private static List<char[]> FindAllPalindroms(List<char[]> list)
        {
            var result = new List<char[]>();
            foreach (var arr in list)
            {
                if (arr.Length < 2) continue;

                var i = 0;
                var j = arr.Count() - 1;               

                var isPolindroms = true;
                while (i < arr.Count() / 2)
                {
                    if (arr[i] != arr[j])
                        isPolindroms = false;
                    i++; j--;
                }

                if(isPolindroms)
                    result.Add(arr);
            }

            return result;
        }
    }
}
