using System.Collections.Generic;
using System.Linq;

namespace YatzyGame.Filters
{
    internal class StraightsFilter : IFilter
    {
        private readonly List<int> _matchValues;

        public StraightsFilter(List<int> matchValues)
        {
            _matchValues = matchValues;
        }

        public IEnumerable<Die> Filter(List<Die> dice)
        {

            var orderedDice = dice.OrderBy(die => die.Value).Select(die => die.Value);
            
            return orderedDice.SequenceEqual(_matchValues) ? dice : Enumerable.Empty<Die>().ToList();
            
        }
    }
}