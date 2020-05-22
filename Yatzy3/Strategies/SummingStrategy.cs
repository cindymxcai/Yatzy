using System.Collections.Generic;
using System.Linq;

namespace YatzyGame.Strategies
{
    internal class SummingStrategy : IAggregationStrategy
    {
        public int Aggregate(IEnumerable<Die> filteredDice)
        {
            return filteredDice.Sum(d => d.Value);
        }
    }
}