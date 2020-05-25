using System;
using System.Collections.Generic;
using YatzyGame.Filters;

namespace YatzyGame.Scoring
{
    public static class ScoreCalculatorFactory
    {
        public static ScoreCalculator CreateCalculator(Category category, List<Die> dice) 
            => category.CategoryName switch
            {
                CategoryName.Ones => new ScoreCalculator(dice,new SummingScorer(new NumberFilter(1)) ),
                CategoryName.Twos => new ScoreCalculator(dice, new SummingScorer(new NumberFilter(2))),
                CategoryName.Threes => new ScoreCalculator(dice, new SummingScorer(new NumberFilter(3))),
                CategoryName.Fours => new ScoreCalculator(dice, new SummingScorer(new NumberFilter(4))),
                CategoryName.Fives => new ScoreCalculator(dice, new SummingScorer(new NumberFilter(5))),
                CategoryName.Sixes=> new ScoreCalculator(dice, new SummingScorer(new NumberFilter(6))),
                CategoryName.Pairs => new ScoreCalculator(dice, new SummingScorer(new OfAKindFilter(2, 1))),
                CategoryName.TwoPairs => new ScoreCalculator(dice, new SummingScorer(new OfAKindFilter(2, 2))),
                CategoryName.ThreeOfAKind => new ScoreCalculator(dice, new SummingScorer(new OfAKindFilter(3, 1))),
                CategoryName.FourOfAKind => new ScoreCalculator(dice, new SummingScorer(new OfAKindFilter(4, 1))),
                CategoryName.SmallStraight => new ScoreCalculator(dice, new SummingScorer(new StraightsFilter(new List<int>{1,2,3,4,5}))),
                CategoryName.LargeStraight => new ScoreCalculator(dice, new SummingScorer(new StraightsFilter(new List<int>{2,3,4,5,6}))),
                CategoryName.FullHouse => new ScoreCalculator(dice, new SummingScorer(new FullHouseFilter())),
                CategoryName.Chance => new ScoreCalculator(dice, new SummingScorer(new NoFilter())),
                CategoryName.Yatzy => new ScoreCalculator(dice, new YatzyScorer(new OfAKindFilter(5, 1))),
                _ => throw new Exception("Invalid Category")
            };
    }
}