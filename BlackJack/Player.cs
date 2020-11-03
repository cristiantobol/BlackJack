using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Player : Participant
    {
        private List<Card> PlayersCards = new List<Card>();

        public Player()
        {
            Name = "Player";
            Cards = PlayersCards;
        }
    }
}
