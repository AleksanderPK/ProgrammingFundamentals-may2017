using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_FixEmails
{
    class E04_FixEmails
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var email = string.Empty;
            var emails = new Dictionary<string, string>();

            while (name != "stop")
            {
                email = Console.ReadLine();
                VerificateAndAddEmail(emails, name, email);
                name = Console.ReadLine();
            }

            foreach (var kvp in emails)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }       

        private static void VerificateAndAddEmail(Dictionary<string, string> emails, string name, string email)
        {
            if (!(email.ToLower().EndsWith(".uk") || email.ToLower().EndsWith(".us")))
            {
                emails.Add(name, email);
            }            
        }
    }
}


