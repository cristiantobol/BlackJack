using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Card> deck = DeckShuffle.GetDeck();
            deck.Shuffle();

            Console.ReadKey();
        }
    }
}
