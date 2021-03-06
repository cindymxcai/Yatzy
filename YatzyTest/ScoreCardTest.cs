using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class ScoreCardTest
    {
        [Fact]
        public void ScoreCardSetUpShouldAssignNameToEachCategory()
        {
            var scoreCard = new ScoreCard();
            Assert.Equal("Ones",scoreCard.CategoryScoreCard[0].CategoryName);
            Assert.Equal(false,scoreCard.CategoryScoreCard[0].IsUsed);
            Assert.Equal(0,scoreCard.CategoryScoreCard[0].CategoryScore);
        }
    }
}