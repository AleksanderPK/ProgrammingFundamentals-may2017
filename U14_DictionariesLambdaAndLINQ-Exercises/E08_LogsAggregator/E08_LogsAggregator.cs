using System;
using System.Collections.Generic;
using System.Linq;


namespace E08_LogsAggregator
{
    class E08_LogsAggregator
    {
        static void Main(string[] args)
        {
            var userIPs = new Dictionary<string, Dictionary<string, int>>();
            getUserInformation(userIPs);
            userIPs = sortUserInformation(userIPs);
            printResult(userIPs);            
        }

        private static void printResult(Dictionary<string, Dictionary<string, int>> userIPs)
        {
            foreach (var user in userIPs)
            {
                var totalDuration = userIPs[user.Key].Values.Sum();
                var allIPs = userIPs[user.Key].Keys;
                Console.WriteLine($"{user.Key}: {totalDuration} [{string.Join(", ", allIPs)}]");
            }
        }

        private static Dictionary<string, Dictionary<string, int>> sortUserInformation(
            Dictionary<string, Dictionary<string, int>> userIPs)
        {
            var sortedUserInfo = new Dictionary<string, Dictionary<string, int>>();

            foreach (var user in userIPs)
            {
                sortedUserInfo[user.Key] = userIPs[user.Key]
                    .OrderBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);
            }

            sortedUserInfo = sortedUserInfo
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            return sortedUserInfo;
        }

        private static void getUserInformation(Dictionary<string, Dictionary<string, int>> userIPs)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputInfo = Console.ReadLine().Split(' ');
                var ip = inputInfo.First();
                var user = inputInfo[1];
                var duration = int.Parse(inputInfo.Last());

                if (!userIPs.ContainsKey(user))
                {
                    userIPs[user] = new Dictionary<string, int>();
                }

                if (!userIPs[user].ContainsKey(ip))
                {
                    userIPs[user][ip] = 0;
                }

                userIPs[user][ip] += duration;
            }
        }
    }
}
