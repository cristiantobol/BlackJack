﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BlackJack
{
    public static class DeckShuffle
    {
        static Random _random = new Random();

        public static void Shuffle<T>(this IList<T> array)
        {
            int n = array.Count;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + _random.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }

        public static IList<Card> GetDeck()
        {
            string path = Directory.GetParent(AppContext.BaseDirectory).FullName + "\\TechnicalTaskCards.json";
            Deck deck;

            try
            {
                deck = JsonConvert.DeserializeObject<Deck>(File.ReadAllText(path));

                foreach (var item in deck.Card)
                {
                    switch (item.Suit)
                    {
                        case "spades":
                            item.Suit = Suits.Spades;
                            break;
                        case "diamonds":
                            item.Suit = Suits.Diamonds;
                            break;
                        case "clubs":
                            item.Suit = Suits.Clubs;
                            break;
                        case "hearts":
                            item.Suit = Suits.Hearts;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deck.Card;
        }
    }
}