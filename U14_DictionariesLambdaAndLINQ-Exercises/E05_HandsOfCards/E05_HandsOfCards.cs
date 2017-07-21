using System;
using System.Collections.Generic;
using System.Linq;

namespace E05_HandsOfCards
{
    class E05_HandsOfCards
    {
        static void Main(string[] args)
        {

            var playersCards = new Dictionary<string, List<string>>();                
            GetHandsOfCards(playersCards);
            foreach (var player in playersCards)
            {
                Console.WriteLine($"{player.Key} - > {ConvertCardsInPoints(player.Value)}");
            }                        
        }

        private static void GetHandsOfCards(Dictionary<string, List<string>> playersCards)
        {
            var input = Console.ReadLine();

            while (input != "JOKER")
            {
                var player = input.Split(':').First();
                var cards = input
                    .Remove(0, input.IndexOf(':') + 1)
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList<string>();

                if (!playersCards.ContainsKey(player))
                {
                    playersCards[player] = new List<string>();
                }

                playersCards[player] = playersCards[player].Concat(cards).ToList();
                playersCards[player] = playersCards[player].Distinct().ToList();
                
                input = Console.ReadLine();
            }
        }

        private static int ConvertCardsInPoints(List<string> cards)
        {
            var sum = 0;

            foreach (var card in cards)
            {
                sum += DefineValue(card);
            }
            return sum;
        }

        private static int DefineValue(string card)
        {
            var result = 0;
            var power = card.Length > 2 ? card.Substring(0, 2).ToString() : card[0].ToString();
            var type = card.Length > 2 ? card.Substring(2, 1).ToString() : card[1].ToString();

            var from2To10 = int.TryParse(power, out result);

            if (!from2To10)
            {
                switch (card[0].ToString())
                {
                    case "J": result = 11; break;
                    case "Q": result = 12; break;
                    case "K": result = 13; break;
                    case "A": result = 14; break;
                    default: break;
                }
            }
            switch (type)
            {
                case "S": result *= 4; break;
                case "H": result *= 3; break;
                case "D": result *= 2; break;
                case "C": result *= 1; break;
                default: break;
            }
            return result;
        }        
    }
}
