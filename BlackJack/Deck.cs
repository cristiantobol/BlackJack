using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Deck
    {
        public IList<Card> Card { get; set; }

        public void ToConsole()
        {
            foreach (var item in Card)
            {
                switch (item.Suit)
                {
                    case "spades":
                        item.Suit = Suits.Spades;
                        break;
                    case "diamonds":
                        item.Suit = Suits.Diamonds;
                        break;
                    case "clubs":
                        item.Suit = Suits.Clubs;
                        break;
                    case "hearts":
                        item.Suit = Suits.Hearts;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
