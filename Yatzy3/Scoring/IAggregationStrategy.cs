using System.Collections.Generic;
using YatzyGame.Filters;

namespace YatzyGame.Scoring
{
    public interface IAggregationStrategy
    {
        int Aggregate(List<Die> dice);
    }
}