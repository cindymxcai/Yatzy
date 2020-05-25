using System;
using System.Collections.Generic;
using System.Linq;
using YatzyGame.InputOutput;
using YatzyGame.Scoring;

namespace YatzyGame
{
    public class Game
    {
        private IRng Rng { get; }
        
        private readonly Player _player;
        
        private readonly ScoreCard _scoreCard;
        public bool IsPlayingGame { get; private set; } = true;

        public List<Die> DiceCup { get; } = new List<Die> {new Die(), new Die(), new Die(), new Die(), new Die()};

        public Game(Player player, ScoreCard scoreCard, IRng rng)
        {
            Rng = rng;
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
            Response response;
            var round = new Round();
            Display.NewRoundTitle();
            do
            {
                round.RollDice(DiceCup, Rng);
                Display.DisplayCategories(_scoreCard, DiceCup.ToList());
                Display.DisplayDice(DiceCup);
                Display.RollsLeft(round.RollsLeft);
                Display.DisplayPrompt();
                
                do
                {
                    response = _player.Respond();
                    HandleResponse(response);
                } 
                while (response.ResponseType == ResponseType.InvalidResponse);
            } 
            while (response.ResponseType == ResponseType.RerollDice || response.ResponseType == ResponseType.HoldDice);
        }

        public void HandleResponse(Response response)
        {
            switch (response.ResponseType)
            {
                case ResponseType.QuitGame:
                    IsPlayingGame = false;
                    break;
                case ResponseType.HoldDice:
                    Round.HoldDice(response, DiceCup);
                    break;
                case ResponseType.ScoreInCategory:
                    ScoreForChosenCategory(response);
                    break;
                case ResponseType.RerollDice:
                    break;
                case ResponseType.InvalidResponse:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ScoreForChosenCategory(Response response)
        {
            var chosenCategory = _scoreCard.CheckIfCategoryUsed(response);
            if (chosenCategory.IsUsed)
            {
                response.ResponseType = ResponseType.InvalidResponse;
            }
            else
            {
                chosenCategory.CategoryScore = ScoreCalculatorFactory.CreateCalculator(chosenCategory, DiceCup).Calculate();
                chosenCategory.IsUsed = true;
                if (!_scoreCard.CategoryScoreCard.All(category => category.IsUsed)) return;
                Display.FinishedGame(_scoreCard);
                IsPlayingGame = false;
            }
        }
        
    }
}