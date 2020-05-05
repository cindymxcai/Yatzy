using Yatzy;

namespace YatzyTest
{
    public class TestRng : IRng
    {
        private readonly int _numberToReturn;

        public TestRng(int numberToReturn)
        {
            _numberToReturn = numberToReturn;
        }

        public int Next(int minValue, int maxValue)
        {
            return _numberToReturn;
        }
    }
}