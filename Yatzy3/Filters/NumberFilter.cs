using System.Collections.Generic;
using System.Linq;

namespace YatzyGame.Filters
{
    internal class NumberFilter : IFilter
    {
        private readonly int _number;

        public NumberFilter(int number)
        {
            _number = number;
        }

        public IEnumerable<Die> Filter(List<Die> dice)
        {
            return dice.Where(die => die.Value == _number);
        }
    }
}