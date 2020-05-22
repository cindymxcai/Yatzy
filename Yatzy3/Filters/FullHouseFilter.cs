using System.Collections.Generic;
using System.Linq;

namespace YatzyGame.Filters
{
    internal class FullHouseFilter : IFilter
    {
        public IEnumerable<Die> Filter(List<Die> dice)
        {
            var group = dice.GroupBy(die => die.Value).ToList();

            return group.Count() == 2 && new[] {2, 3}.Contains(group.First().Count()) ? dice : new List<Die>();
        }
    }
}