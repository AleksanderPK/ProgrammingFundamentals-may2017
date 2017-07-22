using System;
using System.Collections.Generic;
using System.Linq;

namespace E06_UserLogs
{
    class E06_UserLogs
    {
        static void Main(string[] args)
        {
            var usersData = new Dictionary<string, Dictionary<string, int>>();
            GetUsersInformation(usersData);
            usersData = usersData.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in usersData)
            {
                Console.WriteLine(user.Key + ":");
                foreach (var information in user.Value)
                {
                    Console.WriteLine($"{information.Key} => {information.Value}");
                }
            }                      
        }  

        private static void GetUsersInformation(Dictionary<string, Dictionary<string, int>> usersData)
        {
            var input = Console.ReadLine(); 

            while (input != "end")
            {
                var userInfo = input.Split(' ').ToArray();
                var userName = userInfo.Last();
                userName = userName.Substring(userName.IndexOf('=') + 1);
                var userIP = userInfo.First();
                userIP = userIP.Substring(userIP.IndexOf('=') + 1);
                var messege = string.Join("", userInfo.Skip(1).Take(1));

                if (messege != string.Empty)
                {
                    if (!usersData.ContainsKey(userName))
                    {
                        usersData[userName] = new Dictionary<string, int>();
                    }

                    if (!usersData[userName].ContainsKey(userIP))
                    {
                        usersData[userName][userIP] = 1;
                    }
                    else
                    {
                        usersData[userName][userIP]++;
                        usersData[userName] = usersData[userName]
                            .OrderByDescending(x => x.Value)
                            .ToDictionary(x => x.Key, x => x.Value);
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
