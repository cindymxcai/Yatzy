using System.Collections.Generic;
using YatzyGame.Filters;

namespace YatzyGame.Scoring
{
    public class ScoreCalculator
    {
        private readonly List<Die> _dice;
        private readonly IAggregationStrategy _aggregationStrategy;

        public ScoreCalculator(List<Die> dice, IAggregationStrategy aggregationStrategy) 
        {
            _dice = dice;
            _aggregationStrategy = aggregationStrategy;
        }

        public int Calculate()
        {
            return _aggregationStrategy.Aggregate(_dice);
        }
    }
}