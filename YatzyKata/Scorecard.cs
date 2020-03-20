using System.Collections.Generic;

namespace YatzyKata
{
    public class Scorecard : IScorecard
    {
        public Scorecard(List<CategoryScore> scores)
        {
            Scores = scores;
        }

        public readonly List<CategoryScore> Scores;
        
        public void AddScore(Category category, int score)
        {
            Scores.Add(new CategoryScore(category, score));
        }
    }
}