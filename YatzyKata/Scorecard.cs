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

        public List<CategoryScore> Scores { get; private set; }
        public void AddScore(Category category, int score)
        {
            if (Scores.Any(newScore => newScore.Category == category))
            {
                throw new Exception("Category already used");
            }
            
            
            Scores.Add(new CategoryScore(category, score));
        }
    }
}