
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyGame : IYatzyGame
    {
        private readonly Player _player;
        private readonly ScoreCard _scoreCard;
        public List<Die> DiceCup { get; } = new List<Die>{new Die(), new Die(), new Die(), new Die(), new Die()};

        public YatzyGame(Player player, ScoreCard scoreCard)
        {
            _player = player;
            _scoreCard = scoreCard;
        }
        public void PlayRound()
        {
            var response = new Response();
            var responseType =  ResponseType.RerollDice;
            var round = new Round();

            while (responseType ==  ResponseType.RerollDice)
            {
                round.RollDice(DiceCup);
                Display.DisplayCategories(_scoreCard);
                response = _player.Respond();
                responseType = response.ResponseType;
            }
            //if response = scoreincategory -> calculate score in scoreCalculator, update the score on Scorecard 
            //if response = quit game, end game
            //if response = holdDice -> set selected die to held.
        }
        
        
    }
}