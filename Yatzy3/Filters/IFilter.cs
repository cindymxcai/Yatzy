using System.Collections.Generic;

namespace YatzyGame.Filters
{
    public interface IFilter
    {
        IEnumerable<Die> Filter(List<Die> dice);
    }
}