using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Ch_01.Arrays_and_Strings
{
    [Question("ch01.q01", "Is Unique")]
    public class Q01_Is_Unique : IQuestion
    {
        private bool IsUniqueChars(string str)
        {
            if (str.Length > 256) return false;

            bool[] charSet = new bool[256];

            foreach (char c in str)
            {
                if (charSet[c])
                    return false;
                charSet[c] = true;
            }

            return true;
        }

        public void Run()
        {
            string[] inputs = new[] {"abcde", "hello", "car", "apple", "kite"};

            foreach (var str in inputs)
            {
                Console.WriteLine($"input {str} : {IsUniqueChars(str)}");
            }
        }
    }
}
