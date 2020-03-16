using Xunit;
using YatzyKata;

namespace DiceTests
{
    public class DieTests
    {
        [Fact]
        public void DieRollShouldChangeValue()
        {
            var rng = new Rng();
            var dice = new Die(rng);
            int firstRoll = dice.RollDie();
            int secondRoll = dice.RollDie();
            Assert.NotSame( firstRoll,  secondRoll);
        }
        
    }
}