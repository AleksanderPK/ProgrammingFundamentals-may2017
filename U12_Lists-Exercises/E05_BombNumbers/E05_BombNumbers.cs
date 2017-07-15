using System;
using System.Collections.Generic;
using System.Linq;

namespace E05_BombNumbers
{
    class E05_BombNumbers
    {
        static void Main(string[] args)
        {
            var inputList = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList<int>();

            var numAndPow = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList<int>();

            var num = numAndPow[0];
            var pow = numAndPow[1];

            var indOfNum = inputList.IndexOf(num);

            while (indOfNum != -1)
            {
                var startInd = indOfNum - pow < 0 ? 0 : indOfNum - pow;
                var endInd = indOfNum + pow >= inputList.Count ? inputList.Count - 1 : indOfNum + pow;

                for (int i = startInd; i <= endInd; i++)
                {
                    inputList.RemoveAt(startInd);
                }

                indOfNum = inputList.IndexOf(num, startInd);
            }

            Console.WriteLine(inputList.Sum());
        }
    }
}
