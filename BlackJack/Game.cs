using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Game
    {    
        private Stack<Card> StackedDeck { get; set; }
        private readonly IList<Card> deck = DeckShuffle.GetDeck();
        private List<Participant> participants = new List<Participant>();
        
        Player player = new Player();
        Dealer dealer = new Dealer();

        public Game()
        {
            deck.Shuffle();
            StackedDeck = new Stack<Card>(deck);
            
            // Add all participants in a list so they cand all receive a card popped from deck in GiveCards method.
            // If there are many participants, probably adding them using an interration would be more suitable.
            participants.Add(player);
            participants.Add(dealer);
        }

        public void GiveCards()
        {
            // Add all participants in a list
            for (int i = 0; i < participants.Count; i++)
            {
                // Give each participant a card from the deck
                participants[i].Cards.Add(StackedDeck.Pop());
            }

            DisplayCardsOnConsole(participants);
        }

        public void Play()
        {         
            string playersChoice;
            GiveCards();

            while (player.CalculateHand() < 621)
            {
                Console.WriteLine("Hit or Hold?");
                playersChoice = Console.ReadLine();

                if (playersChoice == "hit")
                {
                    GiveCards();
                }
                else if (playersChoice == "hold")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid command. Please choose hit or hold.");
                }
            }
        }

        public void DisplayCardsOnConsole(List<Participant> participants)
        {
            int i = 0;
            Console.Clear();
            Console.WriteLine(Environment.NewLine);
            foreach (var participant in participants)
            {
                Console.WriteLine($"=== {participant.Name.ToUpper()}'S CARDS | TOTAL: {(participant.IsDealer ? "**" : participant.CalculateHand().ToString() )} ===");

                foreach (var card in participant.Cards)
                {
                    // Show hidden cards if the participant is dealer.
                    if (participant.IsDealer)
                    {
                        Console.Write("|****|");
                    }
                    else
                    {
                        // Check wheter the card face is a valid int. If not, keep the first letter and make it upper. Ex. jack becomes J.
                        Console.Write("|" + (!int.TryParse(card.Face, out i) ? card.Face.Substring(0, 1).ToUpper() : card.Face)  + (card.Value > 9 ? " " : "  ") + card.Suit + "|");
                    }                  
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
