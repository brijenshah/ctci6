using System;
using Core;

namespace Ch01_Arrays_And_Strings
{
    [Question("ch01.q03", "URLify")]
    public class Q03_URLify : IQuestion
    {
        private void Urlify(char[] str, int trueLength)
        {
            int index = trueLength + SpaceCount(str) * 2;

            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index -= 3;
                }
                else
                {
                    str[index - 1] = str[i];
                    index--;
                }
            }
        }

        private int SpaceCount(char[] str)
        {
            int cnt = 0;
            foreach (char c in str)
            {
                if (c == ' ') cnt++;
            }
            return cnt;
        }

        public void Run()
        {
            string input = "Mr John Smith";
            char[] str = new char[input.Length + (2 * 2) + 1];

            for (int i = 0; i < input.Length; i++)
            {
                str[i] = input[i];
            }

            Urlify(str, input.Length);

            Console.WriteLine($"URLify - input: {input}, output: {new string(str)}");
        }
    }
}
