using System;
using System.Collections.Generic;
using System.Linq;

namespace YatzyKata
{
    public class ScoreCard : IScorecard
    {
        
        public readonly List<CategoryScore> Scores;

        public int Total
        {
            get{ return Scores.Select(score => score.Score).Sum(); }
        }

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
        
    }
}