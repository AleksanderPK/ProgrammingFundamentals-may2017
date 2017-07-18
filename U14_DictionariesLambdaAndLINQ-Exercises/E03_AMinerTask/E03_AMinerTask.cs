using System;
using System.Collections.Generic;
using System.Linq;

namespace E03_AMinerTask
{
    class E03_AMinerTask
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var container = new List<string>();
            var resources = new Dictionary<string, string>();

            while (input != "stop")
            {
                container.Add(input);
                input = Console.ReadLine();                
            }

            for (int i = 0; i < container.Count; i+= 2)
            {
                resources[container[i]] = container[i + 1];
            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
