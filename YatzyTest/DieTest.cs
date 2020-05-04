using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class DieTest
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
}