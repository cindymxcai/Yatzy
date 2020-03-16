using System;
using System.Collections.Generic;

namespace YatzyKata
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Yatzy!");
            Rng rng = new Rng();
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3,dice4, dice5,new UserInput());   
            game.Hold(new List<bool>{false,false,false, false,false});
            game.RollDice();
        }
    }
}