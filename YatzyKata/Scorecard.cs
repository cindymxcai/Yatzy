using System;
using System.Collections.Generic;
using System.Linq;

namespace YatzyKata
{
    public class Scorecard
    {
        public Scorecard(List<CategoryScore> scores)
        {
            Scores = scores;
        }

        public List<CategoryScore> Scores = new List<CategoryScore>();
        
        public void AddScore(Category category, int score)
        {
          
            if ( Scores.Any(newScore => newScore.Category == category))
            {
                if (Scores.Any(newScore => newScore.Category != Category.None))
                {
                    throw new Exception("Category already used");
                }
            }
            
            Scores.Add(new CategoryScore(category, score));
        }
    }
}