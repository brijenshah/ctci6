using System.Linq;
using Core;

namespace Ch_01.Arrays_and_Strings
{
    [Question("ch01.q02", "Check Permutation")]
    public class Q02_Check_Permutation : IQuestion
    {
        private bool CheckPermutation(string source, string target)
        {
            if (source.Length != target.Length) return false;

            var sortedSource = new string(source.OrderBy(c => c).ToArray());
            var sortedTarget = new string(target.OrderBy(c => c).ToArray());

            return sortedSource.Equals(sortedTarget);
        }

        private bool CheckPermutation2(string source, string target)
        {
            if (source.Length != target.Length) return false;

            int[] charMap = new int[256];

            foreach (char c in source)
            {
                charMap[c]++;
            }

            foreach (char c in target)
            {
                if (charMap[c]-- < 0)
                    return false;
            }

            return true;
        }


        public void Run()
        {
            
        }
    }
}
