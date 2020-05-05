using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyGame
    {
        private IRng Rng { get; }
        private readonly Player _player;
        private readonly ScoreCard _scoreCard;
        public bool IsPlayingGame { get; private set; } = true;

        public List<Die> DiceCup { get; } = new List<Die>
        {
            new Die(),
            new Die(),
            new Die(),
            new Die(),
            new Die()
        };

        public YatzyGame(Player player, ScoreCard scoreCard, IRng rng)
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
                Display.DisplayCategories(_scoreCard, DiceCup.Select(die => die.Value).ToList());
                Display.DisplayDice(DiceCup);
                Display.RollsLeft(round.RollsLeft);
                Display.DisplayPrompt();
                do
                {
                    response = _player.Respond();
                    HandleResponse(response, round);
                } while (response.ResponseType == ResponseType.InvalidResponse);
            } while (response.ResponseType == ResponseType.RerollDice ||
                     response.ResponseType == ResponseType.HoldDice);
        }

        public void HandleResponse(Response response, Round round)
        {
            if (response.ResponseType == ResponseType.QuitGame)
            {
                IsPlayingGame = false;
            }
            else if (response.ResponseType == ResponseType.HoldDice)
            {
                Round.HoldDice(response, DiceCup);
            }
            else if (response.ResponseType == ResponseType.ScoreInCategory)
            {
                var chosenCategory = _scoreCard.CheckIfCategoryUsed(response);
                if (chosenCategory.IsUsed)
                {
                    response.ResponseType = ResponseType.InvalidResponse;
                }
                else
                {
                    chosenCategory.CategoryScore =
                        ScoreCalculator.CalculateScore(DiceCup.Select(die => die.Value), response.Input);
                    chosenCategory.IsUsed = true;
                    if (!_scoreCard.CategoryScoreCard.All(category => category.IsUsed)) return;
                    Display.FinishedGame(_scoreCard);
                    IsPlayingGame = false;
                }
            }
        }
    }
}