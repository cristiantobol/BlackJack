using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Participant : IParticipant
    {
        public string Name { get; set; }
        public bool IsDealer { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();

        public int CalculateHand()
        {
            return Cards.Sum(x => Convert.ToInt32(x.Value));
        }

        public List<Card> GetCards()
        {
            return Cards;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
