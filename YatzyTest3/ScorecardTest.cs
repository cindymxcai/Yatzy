using Xunit;
using YatzyGame;

namespace DieTest
{
    public class ScorecardTest
    {
        [Fact]
        public void ScoreCardSetUpShouldAssignNameToEachCategory()
        {
            var scoreCard = new ScoreCard();
            Assert.Equal(CategoryName.Ones,scoreCard.CategoryScoreCard[0].CategoryName);
            Assert.Equal(false,scoreCard.CategoryScoreCard[0].IsUsed);
            Assert.Equal(0,scoreCard.CategoryScoreCard[0].CategoryScore);
        }
    }
}