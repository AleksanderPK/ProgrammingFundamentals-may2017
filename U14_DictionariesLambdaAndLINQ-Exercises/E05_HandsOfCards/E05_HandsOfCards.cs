using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace E05_HandsOfCards
{
    class E05_HandsOfCards
    {
        static void Main(string[] args)
        {
            var separators = new char[] { ' ', ',', ':' }; 
            var input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var playersCards = new Dictionary<string, string>();
            var playersResults = new Dictionary<string, int>();
            var player = input[0];
            var cards = input.Skip(1).ToArray();

            while (player != "JOKER")
            {
                if (!playersCards.ContainsKey(player))
                {
                    playersCards[player] = string.Empty;
                }
                playersCards[player] = string.Concat(playersCards[player] + " ", string.Join(" ", cards));
                input = Console.ReadLine()
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                player = input[0];
                cards = input.Skip(1).ToArray();
            }

            playersCards = RemoveRepeatedCards(playersCards);

            foreach (var kvp in playersCards)
            {
                var cardsAsArray = kvp.Value
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Console.WriteLine($"{kvp.Key}: {ConvertCardsInPoints(cardsAsArray)}");
            }
        }  
        private static int ConvertCardsInPoints(string[] cards)
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
            var from2To10 = int.TryParse(card[0].ToString(), out result);

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
            switch (card[1].ToString())
            {
                case "S": result *= 4; break;
                case "H": result *= 3; break;
                case "D": result *= 2; break;
                case "C": result *= 1; break;
                default: break;
            }
            return result;
        }
        private static Dictionary<string, string> RemoveRepeatedCards(Dictionary<string, string> playersCards)
        {
            var result = new Dictionary<string, string>();
            
            foreach (var player in playersCards)
            {
                var groupedCards = player.Value.Split(
                    new char[] { ' ', ',', ':' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(x => x).ToArray();
                                
                var cards = string.Empty;
                foreach (var card in groupedCards)
                {
                    cards = string.Concat(cards + " ", card.Key);
                }

                var name = player.Key;
                result[name] = cards;
            }
            return result;
        }
    }
}
