using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAlgorithms
{
    public static class CampareTwoArrays
    {
        public static bool CompairTwoCharArrays(this char[] list, char[] compairTo)
        {
            if (list.Length != compairTo.Length) return false;

            var i = 0;            
            while(i < list.Count())
            {
                if (list[i] != compairTo[i])
                    return false;
                i++;
            }

            return true;
        }
    }
}
