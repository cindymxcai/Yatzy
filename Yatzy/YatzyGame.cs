
using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class YatzyGame
    {
        private readonly Player _player;
        public List<Die> DiceCup { get; } = new List<Die>{new Die(), new Die(), new Die(), new Die(), new Die()};

        public YatzyGame(Player player)
        {
            _player = player;
        }
        public void PlayRound()
        {
            var round = new Round();
            round.RollDice(DiceCup);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_________________________________________");
            Console.WriteLine(
                "Enter: \n Category number to score \n Dice letter to hold\n or R to reroll all dice");
             _player.GetResponse();
        }
    }
}