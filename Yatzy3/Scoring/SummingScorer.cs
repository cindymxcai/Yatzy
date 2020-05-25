using System.Collections.Generic;
using System.Linq;
using YatzyGame.Filters;

namespace YatzyGame.Scoring
{
    internal class SummingScorer : IAggregationStrategy
    {
        private readonly IFilter _filter;

        public SummingScorer(IFilter filter)
        {
            _filter = filter;
        }
        public int Aggregate(List<Die> dice)
        {
            return _filter.Filter(dice).Sum(d => d.Value);
        }
    }
}