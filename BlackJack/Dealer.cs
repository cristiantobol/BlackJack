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
        public int PlayersCardsSum { get; private set; }

        public IList<Card> deck = DeckShuffle.GetDeck();
        int[] usedCards = new int[2];

        public Dealer()
        {
            deck.Shuffle();
            DealersHand = new List<Card>();
            PlayersHand = new List<Card>();
        }

        public int SumDealerCards(List<Card> cards)
        {
            return cards.Sum(x => Convert.ToInt32(x.Value));
        }

        public void SumPlayerCards(List<Card> cards)
        {
            PlayersCardsSum = cards.Sum(x => Convert.ToInt32(x.Value));
        }

        public void RemoveUsedCards(int[] usedCards)
        {
            for (int i = 0; i < usedCards.Length; i++)
            {
                deck.RemoveAt(i);
            }
        }

        public void Hit()
        {
            int index = 0;
           
            PlayersCard = deck[index];
            PlayersHand.Add(PlayersCard);
            DealersHand.Add(deck[index + 1]);

            SumPlayerCards(PlayersHand);
            RemoveUsedCards(usedCards);
        }

        public void Hold()
        {
            SumDealerCards(DealersHand);
        }
    }
}
