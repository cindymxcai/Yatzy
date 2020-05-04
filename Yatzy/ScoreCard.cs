using System.Collections.Generic;

namespace Yatzy
{
    public class ScoreCard
    {
        public List<Category> CategoryScoreCard { get; } 

        public ScoreCard()
        {
            CategoryScoreCard = new List<Category>
            {
                new Category("a", "Ones"),
                new Category("b", "Twos"),
                new Category("c", "Threes"),
                new Category("d", "Fours"),
                new Category("e", "Fives"),
                new Category("f", "Sixes"),
                new Category("g", "Pairs"),
                new Category("h", "Two Pairs"),
                new Category("i", "Three Of A Kind"),
                new Category("j", "Four Of A Kind"),
                new Category("k", "Small Straight"),
                new Category("l", "Large Straight"),
                new Category("m", "Full House"),
                new Category("n", "Chance"),
                new Category("o", "Yatzy")
            };
            
        }
        
    }
}