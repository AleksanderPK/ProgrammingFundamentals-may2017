using System;
using System.Collections.Generic;
using System.Linq;

namespace E03_ArrayManipulator
{
    class E03_ArrayManipulator
    {
        public static void Main(string[] args)
        {
            var inputList = //new List<int>() { 1, 2, 3, 4};
            Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

            var commandLine = // new List<string>() { "sumPairs", "2", };
            Console.ReadLine()
            .Split(' ')
            .ToList();

            while (commandLine[0] != "print")
            {
                var command = commandLine[0];
                commandLine.RemoveAt(0);
                var intElm = commandLine.Select(int.Parse).ToList();

                switch (command)
                {
                    case "add":
                        inputList.Insert(intElm[0], intElm[1]);
                        break;

                    case "addMany":
                        for (int index = intElm[0], j = 1; j < intElm.Count; index++, j++)
                        {
                            inputList.Insert(index, intElm[j]);
                        }
                        break;

                    case "contains":
                        Console.WriteLine(inputList.Contains(intElm[0]) ? inputList.IndexOf(intElm[0]) : -1);
                        break;

                    case "remove":
                        inputList.RemoveAt(intElm[0]);
                        break;

                    case "shift":
                        for (int i = 0; i < intElm[0]; i++)
                        {
                            var buffer = inputList[0];
                            for (int j = 1; j < inputList.Count; j++)
                            {
                                inputList[j - 1] = inputList[j];
                            }
                            inputList[inputList.Count - 1] = buffer;
                        }
                        break;

                    case "sumPairs":
                        var resultList = new List<int>();
                        for (int i = 0; i < inputList.Count; i+=2)
                        {
                            var sum = inputList[i] + inputList[i + 1];
                            resultList.Add(sum);
                        }

                        inputList = new List<int>(resultList);
                        break;

                    default:
                        break;
                }

                commandLine = Console.ReadLine().Split(' ').ToList();
            }

            Console.WriteLine($"[{string.Join(", ", inputList)}]");
        }
        
    }
}
