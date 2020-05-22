using System.Collections.Generic;

namespace YatzyGame.Strategies
{
    public interface IAggregationStrategy
    {
        int Aggregate(IEnumerable<Die> filteredDice);
    }
}