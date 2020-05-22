using System.Collections.Generic;
using System.Linq;

namespace YatzyGame.Strategies
{
    internal class YatzyStrategy : IAggregationStrategy
    {
        public int Aggregate(IEnumerable<Die> dice)
        {
            return dice.Count() >= 5 ? 50 : 0;
        }
    }
}