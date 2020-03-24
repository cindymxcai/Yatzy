using Xunit;
using YatzyKata;

namespace DiceTests
{
    public class DieTests
    {
        [Fact]
        public void DieRollShouldChangeValue()
        {
            var rng = new TestRng(4);
            var dice = new Die(rng);
            int firstRoll = dice.RollDie();
            rng.ChangeReturnValue(1);
            int secondRoll = dice.RollDie();
            Assert.NotEqual( firstRoll,  secondRoll);
        }
    }
}