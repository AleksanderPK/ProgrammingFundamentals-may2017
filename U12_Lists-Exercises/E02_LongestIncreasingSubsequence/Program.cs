using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var len = new List<int>(input.Count);
            var prev = new List<int>(input.Count);
            var result = new List<int>();

            var maxLenth = 1;
            var lastIndex = 0;

            for (int i = 0; i < input.Count; i++)
            {
                len.Add(1);
                prev.Add(-1);
            }

            for (int i = 1; i < input.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var key = len[j] + 1 > len[i];

                    if (input[j] < input[i] && key)
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLenth)
                {
                    maxLenth = len[i];
                    lastIndex = i;
                }
            }

            result.Add(input[lastIndex]);
            lastIndex = prev[lastIndex];

            while (lastIndex != -1)
            {
                result.Add(input[lastIndex]);
                lastIndex = prev[lastIndex];
            }


            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
