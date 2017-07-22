using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E07_PopulationCounter
{
    class E07_PopulationCounter
    {
        static void Main(string[] args)
        {
            var counrtyData = new Dictionary<string, Dictionary<string, int>>(); 
            GetData(counrtyData);
            counrtyData = SortData(counrtyData);

            Console.WriteLine();
            foreach (var country in counrtyData)
            {
                var totalPopulation = country.Value.Values.Sum();                
                Console.WriteLine(country.Key + " (total popultion: " + totalPopulation + ")");
                foreach (var city in country.Value)
                {
                    Console.WriteLine($"=> {city.Key}: {city.Value}");
                }
            }
        }

        private static Dictionary<string, Dictionary<string, int>> SortData(
            Dictionary<string, Dictionary<string, int>> counrtyData)
        {
            var sortedData = new Dictionary<string, Dictionary<string, int>>();

            foreach (var country in counrtyData)
            {
                sortedData[country.Key] = country
                    .Value.OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, y => y.Value);
            }

            sortedData = sortedData
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, y => y.Value);

            return sortedData;
        }

        private static void GetData(
            Dictionary<string, Dictionary<string, int>> counrtyData)
        {
            var input = Console.ReadLine();

            while (input != "report")
            {
                var inputAsArr = input.Split('|').ToArray();
                var city = inputAsArr.First();
                var country = string.Join(" ", inputAsArr.Skip(1).Take(1));
                var popultation = int.Parse(inputAsArr.Last());

                if (!counrtyData.ContainsKey(country))
                {
                    counrtyData[country] = new Dictionary<string, int>();
                }

                if (!counrtyData[country].ContainsKey(city))
                {
                    counrtyData[country][city] = 0;
                }

                counrtyData[country][city] += popultation;
                input = Console.ReadLine();
            }
        }
    }
}
