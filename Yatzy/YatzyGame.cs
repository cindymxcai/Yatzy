
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
            var responseType = Response.RerollDice;
            var round = new Round();

            while (responseType == Response.RerollDice)
            {
                round.RollDice(DiceCup);
                Display.DisplayDice(DiceCup);
                responseType =_player.Response();
            }
            
            HandleResponse();
        }
        
        private void HandleResponse()
        {
            if (_player.Response() == Response.ScoreInCategory)
            {
                
            }
        }
        
    }
}