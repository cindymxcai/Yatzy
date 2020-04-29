using System;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class Tests
    {
        [Fact]
        public void DiceShouldReturnValueWhenRolled()
        {
            var die = new Die();
            var rng = new TestRng(1);
            die.Roll(rng); 
            var value = die.Value;
            Assert.Equal(1, value);
        }
        
        [Fact]
        public void DiceShouldChangeValueWhenRolledAgain()
        {
            var die = new Die();
            var testRng = new TestRng(1);
            die.Roll(testRng);
            var rng = new TestRng(4);
            die.Roll(rng);
            var value = die.Value;
            Assert.NotEqual(1, value);
        }
    }

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