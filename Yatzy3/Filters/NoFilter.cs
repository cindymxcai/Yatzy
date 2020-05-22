using System.Collections.Generic;

namespace YatzyGame.Filters
{
    internal class NoFilter : IFilter
    {
        public IEnumerable<Die> Filter(List<Die> dice)
        {
            return dice;
        }
    }
}