using System;
using System.Linq;
using System.Collections.Generic;

namespace E01_MaxSequenceOfEqualElements
{
    class E01_MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            var input = new List<int> { 5, 5, 5,5,5,5,5, 2,2,2,2,2,2,2, 1, 1, 1, 1, 1, 1 }; //Console.ReadLine().Split(' ').Select(dig => int.Parse(dig));

            var container = new List<int>();
            var result = new List<int>();
            var counter = 1;
            var maxCounter = 0;

            for (int i = 0; i < input.Count; i++)
            {
                var currentDig = input[i];
                container.Add(currentDig);

                for (int j = i + 1; j < input.Count; j++)
                {
                    if (currentDig == input[j])
                    {
                        counter++;
                        container.Add(input[j]);

                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            result = new List<int>(container);
                        }                        
                    }
                    else
                    {
                        counter = 1;
                        i = j - 1;
                        break;
                    }

                    i = j - 1;
                }
                
                container.Clear();
            }

            foreach (var elm in result) 
            {
                Console.Write(elm + " ");
            }


        }
    }
}
