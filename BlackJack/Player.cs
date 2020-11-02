using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Player : Participant
    {
        public readonly string name = "Player";
        private int hand;
        string playerChoice;

        protected int GetHand()
        {
            return hand;
        }

        private void SetHand(int value)
        {
            hand = value;
        }

        public void Play()
        {         
            Dealer dealer = new Dealer();          
            dealer.Hit();
            SetHand(0);

            while (hand < 21)
            {   
                
                Console.WriteLine("Hit or Hold?");
                playerChoice = Console.ReadLine();
                if(playerChoice == "hit")
                {
                    Console.WriteLine(dealer.Hit().Value + " " + dealer.Hit().Suit);                
                }
                else if(playerChoice == "hold")
                {                 
                    break;
                }
                //Console.WriteLine("|" + item.Value + (item.Value > 9 ? " " : "  ") + item.Suit + "|");
                //SetHand(hand += int.Parse(playerChoice));
            }
            Console.WriteLine(dealer.DealersHand);
        }

        
    }
}
