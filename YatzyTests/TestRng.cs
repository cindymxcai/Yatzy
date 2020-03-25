using System.Collections.Generic;
using YatzyKata;

namespace DiceTests
{
    public class TestRng : IRng
    {
        private int _numberToReturn;

        public TestRng(int numberToReturn)
        {
            _numberToReturn = numberToReturn;
        }

        public int Next(int minValue, int maxValue)
        {
            return _numberToReturn;
        }

        public void ChangeReturnValue(int n)
        {
            _numberToReturn = n;
        }
    }
}