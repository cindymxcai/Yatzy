using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyGame : IYatzyGame
    {
        private readonly Player _player;
        private readonly ScoreCard _scoreCard;
        public bool IsPlayingGame = true;

        public List<Die> DiceCup { get; } = new List<Die>{new Die(), new Die(), new Die(), new Die(), new Die()};

        public YatzyGame(Player player, ScoreCard scoreCard)
        {
            _player = player;
            _scoreCard = scoreCard;
        }

        public void PlayGame()
        {
            while (IsPlayingGame)
            {
                PlayRound();
            }
        }
        public void PlayRound()
        {
            var response = new Response();
            var round = new Round();

            Display.NewRoundTitle();
            
            do
            {
                try {
                    round.RollDice(DiceCup);
                }
                //TODO: HOW DO YOU TEST THIS?
                catch (RoundOverException exceptionMessage)
                {
                    throw exceptionMessage;
                }
                
                Display.DisplayCategories(_scoreCard, DiceCup.Select(die => die.Value).ToList());
                Display.DisplayDice(DiceCup);
                Display.DisplayPrompt();

                do
                {
                    response = _player.Respond();

                } while (response.ResponseType == ResponseType.InvalidResponse);

            } while (response.ResponseType == ResponseType.RerollDice);
            
            HandleResponse(response);
        }

        private void HandleResponse(Response response)
        {
            if (response.ResponseType == ResponseType.QuitGame)
            {
                IsPlayingGame = false;
            }
            
            else if(response.ResponseType == ResponseType.HoldDice)
            {
                // handle method to hold and reroll some dice
            } 
            
            else if (response.ResponseType == ResponseType.ScoreInCategory)
            {
                var chosenCategory = _scoreCard.CategoryScoreCard.FirstOrDefault(category => category.CategoryKey == response.Input.ToLower());

                //TODO: WHY ISNT THIS GETTING COVERED?
                if (chosenCategory.IsUsed) return;
                chosenCategory.CategoryScore = ScoreCalculator.CalculateScore(DiceCup.Select(die => die.Value), response.Input);
                chosenCategory.IsUsed = true;
            }
        }
    }
}