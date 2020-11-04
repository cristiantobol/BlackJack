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
        private bool isBust = false;
        private bool isHold = false;
        private bool isDraw = false;
        private bool playerWon = false;
        
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

            while (player.CalculateHand() <= 21)
            {               
                Console.WriteLine("Hit or Hold?");
                playersChoice = Console.ReadLine();

                if (playersChoice == "hit")
                {
                    GiveCards();
                    if (dealer.CalculateHand() > 21 && player.CalculateHand() <= 21)
                    {
                        playerWon = true;
                        GameOver();
                        break;
                    }
                }
                else if (playersChoice == "hold")
                {                 
                    Hold();
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid command. Please choose hit or hold.");
                }
            }
            isBust = true;
            GameOver();
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
                        if (isHold)
                        {
                            dealer.ShowDealersHand();
                            Console.WriteLine(Environment.NewLine);
                            if(isDraw)
                            {
                                Draw();
                            }
                        }
                        else
                        {
                            Console.Write("|****|");
                        }                     
                    }
                    else
                    {
                        // Check wheter the card face is a valid int. If not, keep the first letter and make it upper. Ex. jack becomes J.
                        Console.Write("|" + (!int.TryParse(card.Face, out i) ? card.Face.Substring(0, 1).ToUpper() + " " : card.Face)  + (card.Value > 9 ? " " : "  ") + card.Suit + "|");
                    }                  
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        public void Hold()
        {
            DisplayCardsOnConsole(participants);
            if (player.CalculateHand() == dealer.CalculateHand())
            {
                isDraw = true;
                Draw();
            }
            if(player.CalculateHand() > dealer.CalculateHand() && player.CalculateHand() <= 21)
            {
                playerWon = true;
            }
            else
            {
                playerWon = false;
            }
        }

        /// <summary>
        ///  This function is called when player's cards sum is equal to dealer's cards sum but not more than 21.
        /// </summary>
        public void Draw()
        {
            while (true)
            {
                Console.Write("DRAW! Play again? y/n: ");
                var input = Console.ReadLine();

                if(input == "y")
                {
                    Game game = new Game();
                    game.Play();
                }
                else if(input == "n")
                {
                    Console.WriteLine("Bye.");
                }
                else
                {
                    Console.Write("Not a valid input. Please choose y or n: ");
                }
            }
        }

        public void GameOver()
        {
            if (playerWon)
            {
                Console.WriteLine("BUST! Player Won! Play again? y/n: ");
            }
            else
            {
                if (player.CalculateHand() > 21 && dealer.CalculateHand() > 21)
                {
                    Console.WriteLine("BUST! No one won. Play again? y/n: ");
                }
                else
                {
                    Console.WriteLine("BUST! Dealer Won! Play again? y/n: ");
                }
            }

            do
            {
                var input = Console.ReadLine();
                if (input == "y")
                {
                    Game game = new Game();
                    game.Play();
                }
                else if (input == "n")
                {
                    Console.WriteLine("Bye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter valid input y or n: ");
                }
            } while (true);
        }
    }
}
