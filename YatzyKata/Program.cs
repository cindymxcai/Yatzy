﻿using System;

namespace YatzyKata
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Yatzy!");
            var rng = new Rng();
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var consoleReader = new ConsoleReader();
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(consoleReader), new bool[5]);
            game.Play();
        }
    }
}