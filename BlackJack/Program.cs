using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Welcome to BlackJack. Press any key to start the game.");
            Console.WriteLine(Environment.NewLine);
            Console.ReadKey(true);
            

            Player player = new Player();
            player.Play();
        }
    }
}
