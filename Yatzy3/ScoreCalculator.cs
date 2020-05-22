using System.Collections.Generic;
using YatzyGame.Filters;
using YatzyGame.Strategies;

namespace YatzyGame
{
    public class ScoreCalculator
    {
        
        private readonly List<Die> _dice;
        private readonly IFilter _filter;
        private readonly IAggregationStrategy _aggregationStrategy;

        public ScoreCalculator(List<Die> dice, IFilter filter, IAggregationStrategy aggregationStrategy) 
        {
            _dice = dice;
            _filter = filter;
            _aggregationStrategy = aggregationStrategy;
        }

        public int Calculate()
        {
            var filteredDice = _filter.Filter(_dice);
            return _aggregationStrategy.Aggregate(filteredDice);
        }

    }
}