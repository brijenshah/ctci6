using System;
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
                if (--charMap[c] < 0)
                    return false;
            }

            return true;
        }


        public void Run()
        {
            string[] source = new[] { "abc", "xyz", "car", "apple", "kite" };
            string[] target = new[] { "bca", "zyz", "scotter", "mpple", "kite" };

            for (int i = 0; i < source.Length; i++)
            {
                var s = source[i];
                var t = target[i];
                Console.WriteLine($"CheckPermutation: source: {s}, target: {t} : {CheckPermutation(s,t)}");
                Console.WriteLine($"CheckPermutation2: source: {s}, target: {t} : {CheckPermutation2(s, t)}");
            }
        }
    }
}
