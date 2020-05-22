using Xunit;
using YatzyGame;

namespace DieTest
{
    public class CategoryTests
    {
        [Fact]
        public void CategoryToStringTest()
        {
            var scorecard = new ScoreCard();
            Assert.Equal("a) Ones : 0", scorecard.CategoryScoreCard[0].ToString());
        }
    }
}