using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class CategoryTest
    {
        [Fact]
        public void CategoryToStringTest()
        {
            var scorecard = new ScoreCard();
            Assert.Equal("a) Ones : 0", scorecard.CategoryScoreCard[0].ToString());
        }
    }
}