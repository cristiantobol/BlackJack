using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Dealer : Participant
    {
        public readonly string Name = "Dealer";
        public List<Card> DealersHand { get; private set; }
        public List<Card> PlayersHand { get; set; }
        public Card PlayersCard { get; private set; }

        public IList<Card> deck = DeckShuffle.GetDeck();
        int[] usedCards = new int[2];

        public Dealer()
        {
            deck.Shuffle();
        }

        public int SumDealerCards(List<Card> cards)
        {
            return cards.Sum(x => Convert.ToInt32(x));
        }

        public void RemoveUsedCards(int[] usedCards)
        {
            for (int i = 0; i < usedCards.Length; i++)
            {
                deck.RemoveAt(i);
            }
        }

        public Card Hit()
        {
            int index = 0;           
            PlayersCard = deck[index];
            PlayersHand?.Add(PlayersCard);
            DealersHand?.Add(deck[index + 1]);

            RemoveUsedCards(usedCards);

            return PlayersCard;
        }

        public void Hold()
        {
            SumDealerCards(DealersHand);
        }
    }
}
