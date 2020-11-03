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
            Cards = DealersCards;
            IsDealer = true;
        }
    }
}
