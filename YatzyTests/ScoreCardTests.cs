using System.Collections.Generic;
using Xunit;
using YatzyKata;

namespace DiceTests
{
    public class ScoreCardTests
    {
        [Theory]
        [InlineData(Category.Ones, 3)]
        [InlineData(Category.Twos, 4)]
        [InlineData(Category.Yatzy, 12)]
        public void AddScoresAddsCorrectScoreToCategory(Category category, int score)
        {
             var scoreCard =  new ScoreCard( new List<CategoryScore>());
             scoreCard.AddScore(category, score);
             Assert.Equal(scoreCard.Scores, new List<CategoryScore>{new CategoryScore(category, score)});
        }
  
        [Fact]
        public void ScoreCardTotalTest()
        {
            var scoreCard =  new ScoreCard( new List<CategoryScore>());
            scoreCard.AddScore(Category.Ones, 1);
            scoreCard.AddScore(Category.Chance, 14);
            Assert.Equal(15, scoreCard.GetTotal());
        }
    }
}