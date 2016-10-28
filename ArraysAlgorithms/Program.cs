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
            int[] originalList = new int[] { 1, 2, 3,4 };
            Stack<int> currentList = new Stack<int>();
            List<int[]> listOfSubsets = new List<int[]>();

            BuildListOfSubsets(originalList, listOfSubsets, 0, 0, currentList);
        }

        private static void BuildListOfSubsets(int[] originalList, List<int[]> listOfSubsets, int sizeOfSubsetList, int currentLevel, Stack<int> currentList)
        {

            foreach (var v in currentList)
            {
                Console.Write(v + " ");
            }

            Console.WriteLine();

            for (int ix = currentLevel; ix < originalList.Length; ix++)
            {
                currentList.Push(originalList[ix]);
                BuildListOfSubsets(originalList, listOfSubsets, originalList.Length - ix + 1, ix + 1, currentList);
                currentList.Pop();
            }
        }
    }
}
