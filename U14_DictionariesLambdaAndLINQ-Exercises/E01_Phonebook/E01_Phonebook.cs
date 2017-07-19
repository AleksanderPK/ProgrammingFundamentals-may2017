using System;
using System.Linq;
using System.Collections.Generic;

namespace E01_Phonebook
{
    class E01_Phonebook
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine()
                .Split(' ')
                .ToArray();
            var phonebook = new Dictionary<string, string>();
            var command = inputLine[0];
            var name = string.Empty;
            var phoneNumber = string.Empty;
            
            while (command != "END")
            {                
                switch (command)
                {
                    case "A":
                        name = inputLine[1];
                        phoneNumber = inputLine[2];
                        phonebook.Add(name, phoneNumber);
                        break;

                    case "S":
                        name = inputLine[1];
                        if (phonebook.ContainsKey(name))
                        {
                            Console.WriteLine($"{name} -> {phoneNumber}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {name}, does not exists.");
                        }
                        break;

                    case "ListAll":
                        var sortedPhonebook = phonebook.OrderBy(x => x.Key);
                        foreach (var kvp in sortedPhonebook)
                        {
                            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                        }
                        break;

                    default:
                        Console.WriteLine("Please, enter a correct command");
                        break;
                }

                inputLine = Console.ReadLine().Split(' ').ToArray();
                command = inputLine[0];
            }
            
        }
    }
}
