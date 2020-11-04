using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Dealer : Participant, IParticipant
    {
        private List<Card> DealersCards = new List<Card>();

        public Dealer()
        {
            Name = "Dealer";
            IsDealer = true;
        }

        public void ShowDealersHand()
        {
            int i = 0;

            foreach (var card in DealersCards)
            {
                Console.Write("|" + (!int.TryParse(card.Face, out i) ? card.Face.Substring(0, 1).ToUpper() + " " : card.Face) + (card.Value > 9 ? " " : "  ") + card.Suit + "|");
            }
            Console.ReadKey();
        }
    }
}
