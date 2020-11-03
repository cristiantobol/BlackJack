using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Player : Participant
    {
        public readonly string name = "Player";
        public int Hand { get; private set; }
        string playerChoice;
        bool hasHeader;

        public void CalculatePlayerHand(int playerHand)
        {
            Console.WriteLine();
        }

        public void DisplayCardsOnConsole(Card card, bool hasHeader, string name, bool isDealer)
        {
            if(!hasHeader)
            {
                Console.WriteLine($"=== {name.ToUpper()}'S CARDS ===");
            }
            if(isDealer)
            {
                Console.Write("|*  *|");
            }
            else
            {
                Console.Write("|" + card.Value + (card.Value > 9 ? " " : "  ") + card.Suit + "|");
            }           
        }

        public void Play()
        {         
            Dealer dealer = new Dealer();          
            dealer.Hit();

            DisplayCardsOnConsole(dealer.PlayersCard, false, "Player", false);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("TOTAL: " + dealer.PlayersCardsSum);
            Console.WriteLine("----------------------------------------------------");

            DisplayCardsOnConsole(dealer.DealersHand[0], false, "Dealer", true);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("TOTAL: " + dealer.PlayersCardsSum);
            Console.WriteLine("----------------------------------------------------");

            Hand = dealer.PlayersCard.Value;
            
            while (Hand < 21)
            {
                Console.WriteLine("Hit or Hold?");
                playerChoice = Console.ReadLine();
                if(playerChoice == "hit")
                {
                    Hand += dealer.PlayersCard.Value;
                    dealer.Hit();

                    hasHeader = true;
                    foreach (var item in dealer.PlayersHand)
                    {
                        DisplayCardsOnConsole(item, !hasHeader, "Player", false);
                        hasHeader = false;
                    }
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("TOTAL: " + dealer.PlayersCardsSum);
                    Console.WriteLine("----------------------------------------------------");

                    hasHeader = true;
                    foreach (var item in dealer.DealersHand)
                    {
                        DisplayCardsOnConsole(item, !hasHeader, "Dealer", true);
                        hasHeader = false;
                    }
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("TOTAL: " + dealer.PlayersCardsSum);
                    Console.WriteLine("----------------------------------------------------");
                }
                else if(playerChoice == "hold")
                {
                    dealer.Hold();
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid command. Please choose hit or hold.");
                }
            }
        }

        
    }
}
