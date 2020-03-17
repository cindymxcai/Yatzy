using System;
using System.Collections.Generic;
using System.Linq;

namespace YatzyKata
{
    public class Scorecard
    {
        public List<CategoryScore> Scores { get; set; }
        public void AddScore(Category category, int score)
        {
            if (Scores.Any(score => score.Category == category))
            {
                throw new Exception("Category already used");
            }
            
            Scores.Add(new CategoryScore(category, score));
        }
    }
}