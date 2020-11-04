using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public interface IParticipant
    {
        string GetName();
        int CalculateHand();
        List<Card> GetCards();
    }
}
