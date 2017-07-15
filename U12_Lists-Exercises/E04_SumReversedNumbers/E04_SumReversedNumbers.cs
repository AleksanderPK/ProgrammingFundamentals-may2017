using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_SumReversedNumbers
{
    class E04_SumReversedNumbers
    {
        static void Main(string[] args)
        {
            var numList = Console.ReadLine().Split(' ').ToList();
            var sum = 0;

            foreach (var digit in numList)
            {
                var reversedDig = Reverse(digit);
                sum += int.Parse(reversedDig);
            }

            Console.WriteLine(sum);
        }

        public static string Reverse(string num)
        {
            char[] arr = num.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }
    }
}
