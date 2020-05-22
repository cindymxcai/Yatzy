using System.Collections.Generic;
using System.Linq;

namespace YatzyGame.Filters
{
    internal class OfAKindFilter : IFilter
    {
        private readonly int _numberOfKind;
        private readonly int _numberOfGroups;
        
        public OfAKindFilter(int numberOfKind, int numberOfGroups)
        {
            _numberOfGroups = numberOfGroups;
            _numberOfKind = numberOfKind;
        }
        
        public IEnumerable<Die> Filter(List<Die> dice)  
        {
            var groupedDice = dice
                .GroupBy(die => die.Value)
                .Where(group => group.Count() >= _numberOfKind)
                .OrderByDescending(group => group.Key)
                .Take(_numberOfKind)
                .ToList();
            
            if (_numberOfGroups == 1) return groupedDice.FirstOrDefault() ??  Enumerable.Empty<Die>();

            var concatenatedGroups = new List<Die>();
            foreach (var group in groupedDice)
            {
                concatenatedGroups.AddRange(group);
            }
            return _numberOfKind == 2 && concatenatedGroups.Count == 4 ? concatenatedGroups : Enumerable.Empty<Die>();
        }
    }
}