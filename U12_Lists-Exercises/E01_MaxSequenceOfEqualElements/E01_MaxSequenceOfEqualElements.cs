using System;
using System.Linq;
using System.Collections.Generic;

namespace E01_MaxSequenceOfEqualElements
{
    class E01_MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(dig => int.Parse(dig))
                .ToList<int>();            

            var result = new List<int>();
            var container = new List<int>();

            for (int i = 0, j = 0; i < input.Count; i = j)
            {
                container.Add(input[i]);

                for (j = i + 1; j < input.Count; j++)
                {
                    if (input[i] == input[j])
                    {
                        container.Add(input[j]);
                    }
                    else
                    {
                        break;
                    }                                        
                }

                if (container.Count > result.Count)
                {
                    result = new List<int>(container);
                }

                container.Clear();
            }

            result.ForEach(x => Console.Write(x + " "));
        }
    }
}
