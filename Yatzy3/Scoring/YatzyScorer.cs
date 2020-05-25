using System.Collections.Generic;
using System.Linq;
using YatzyGame.Filters;

namespace YatzyGame.Scoring
{
    internal class YatzyScorer : IAggregationStrategy
    {
        private readonly IFilter _filter;

        public YatzyScorer(IFilter filter)
        {
            _filter = filter;
        }
        public int Aggregate(List<Die> dice)
        {
            return _filter.Filter(dice).Count() >= 5 ? 50 : 0;
        }
    }
}