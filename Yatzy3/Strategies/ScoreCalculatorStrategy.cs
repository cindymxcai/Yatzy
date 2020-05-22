using System;
using System.Collections.Generic;
using YatzyGame.Filters;

namespace YatzyGame.Strategies
{
    public static class ScoreCalculatorStrategy
    {
        public static ScoreCalculator CreateCalculator(Category category, List<Die> dice) 
            => category.CategoryName switch
            {
                "Ones" => new ScoreCalculator(dice, new NumberFilter(1), new SummingStrategy()),
                "Twos" => new ScoreCalculator(dice, new NumberFilter(2), new SummingStrategy()),
                "Threes" => new ScoreCalculator(dice, new NumberFilter(3), new SummingStrategy()),
                "Fours" => new ScoreCalculator(dice, new NumberFilter(4), new SummingStrategy()),
                "Fives" => new ScoreCalculator(dice, new NumberFilter(5), new SummingStrategy()),
                "Sixes" => new ScoreCalculator(dice, new NumberFilter(6), new SummingStrategy()),
                "Pairs" => new ScoreCalculator(dice, new OfAKindFilter(2, 1), new SummingStrategy()),
                "Two Pairs" => new ScoreCalculator(dice, new OfAKindFilter(2, 2), new SummingStrategy()),
                "Three Of A Kind" => new ScoreCalculator(dice, new OfAKindFilter(3, 1), new SummingStrategy()),
                "Four Of A Kind" => new ScoreCalculator(dice, new OfAKindFilter(4, 1), new SummingStrategy()),
                "Small Straight" => new ScoreCalculator(dice, new StraightsFilter(new List<int>{1,2,3,4,5}), new SummingStrategy()),
                "Large Straight" => new ScoreCalculator(dice, new StraightsFilter(new List<int>{2,3,4,5,6}), new SummingStrategy()),
                "Full House" => new ScoreCalculator(dice, new FullHouseFilter(), new SummingStrategy()),
                "Chance" => new ScoreCalculator(dice, new NoFilter(), new SummingStrategy()),
                "Yatzy" => new ScoreCalculator(dice, new OfAKindFilter(5, 1), new YatzyStrategy() ),
                _ => throw new Exception("Invalid Category")
            };
    }
}