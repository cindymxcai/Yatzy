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
          
            /*if ( Scores.Any(newScore => newScore.Category == category))
            {
                if (Scores.Any(newScore => newScore.Category != Category.None))
                {
                 //   throw new Exception("Category already used");
                }
            }*/
            
            Scores.Add(new CategoryScore(category, score));
        }
    }
}