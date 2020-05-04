using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyGame 
    {
        private readonly Player _player;
        private readonly ScoreCard _scoreCard;
        public bool IsPlayingGame { get; private set; } = true;

        public List<Die> DiceCup { get; set; } = new List<Die>{new Die(), new Die(), new Die(), new Die(), new Die()};

        public YatzyGame(Player player, ScoreCard scoreCard)
        {
            _player = player;
            _scoreCard = scoreCard;
        }

        public void PlayGame(IRng rng)
        {
            while (IsPlayingGame)
            {
                PlayRound(rng);
            }

            
        }
        public void PlayRound(IRng rng)
        {
            Response response;
            var round = new Round();
            
                Display.NewRoundTitle();

                do
                {
                    try
                    {
                        round.RollDice(DiceCup, rng);
                    }
                    catch (RoundOverException exceptionMessage)
                    {
                        //try not to rethrow an exception that was just caught
                        throw exceptionMessage;
                    }

                    Display.DisplayCategories(_scoreCard, DiceCup.Select(die => die.Value).ToList());
                    Display.DisplayDice(DiceCup);
                    Display.RollsLeft(round.RollsLeft);
                    Display.DisplayPrompt();

                    do
                    {
                        response = _player.Respond();

                    } while (response.ResponseType == ResponseType.InvalidResponse);

                    HandleResponse(response, round);

                } while (response.ResponseType == ResponseType.RerollDice || response.ResponseType == ResponseType.HoldDice);

        }

        private void HandleResponse(Response response, Round round)
        {
            if (response.ResponseType == ResponseType.QuitGame)
            {
                IsPlayingGame = false;
            }
            
            else if(response.ResponseType == ResponseType.HoldDice)
            {
                round.HoldDice(response.Input, DiceCup);
            } 
            
            else if (response.ResponseType == ResponseType.ScoreInCategory)
            {
                var chosenCategory = _scoreCard.CategoryScoreCard.FirstOrDefault(category => category.CategoryKey == response.Input.ToLower());

                //TODO: WHY ISNT THIS GETTING COVERED?
                if (chosenCategory.IsUsed) return;
                chosenCategory.CategoryScore = ScoreCalculator.CalculateScore(DiceCup.Select(die => die.Value), response.Input);
                chosenCategory.IsUsed = true;

                if (!_scoreCard.CategoryScoreCard.All(category => category.IsUsed)) return;
                Display.FinishedGame(_scoreCard);
                IsPlayingGame = false;
            }
        }
    }
}