using System.Collections.Generic;
using System.Linq;

namespace YatzyKata
{
    public class ScoreCard : IScorecard
    {
        
        public readonly List<CategoryScore> Scores;
        public int Total { get; }

        public ScoreCard(List<CategoryScore> scores)
        {
            Scores = scores;
        }

        public void AddScore(Category category, int score)
        {
            Scores.Add(new CategoryScore(category, score));
        }

        public int? GetScore(Category category)
        {
            return Scores.FirstOrDefault(score => score.Category == category)?.Score;

        }

        public int GetTotal()
        {
            var total = Scores.Select(score => score.Score).Sum();
            return total;
        }
    }
}