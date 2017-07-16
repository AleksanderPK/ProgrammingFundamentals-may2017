using System;
using System.Collections.Generic;
using System.Linq;

namespace E2_LongestIncreasingSubsequence
{
    class E02_LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 3, 7, 5, 8, 9 }; //Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var length = new int[nums.Length];
            var prev = new int[nums.Length];
            int maxLength = 0;
            int lastIndex = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                length[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && length[j] + 1 > length[i])
                    {
                        length[i] = length[j] + 1;
                        prev[i] = j;
                    }
                }
                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    lastIndex = i;
                }
            }

            var list = new List<int>();
            while (lastIndex != -1)
            {
                list.Add(nums[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            list.Reverse();
            Console.WriteLine(string.Join("", list));
        }
    }
}


