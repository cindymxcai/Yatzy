using System.Collections.Generic;
using System.Linq;

namespace YatzyGame
{
    public class ScoreCard
    {
        public List<Category> CategoryScoreCard { get; }

        public ScoreCard()
        {
            CategoryScoreCard = new List<Category>
            {
                new Category("a", CategoryName.Ones),
                new Category("b", CategoryName.Twos),
                new Category("c", CategoryName.Threes),
                new Category("d", CategoryName.Fours),
                new Category("e", CategoryName.Fives),
                new Category("f", CategoryName.Sixes),
                new Category("g", CategoryName.Pairs),
                new Category("h", CategoryName.TwoPairs),
                new Category("i", CategoryName.ThreeOfAKind),
                new Category("j", CategoryName.FourOfAKind),
                new Category("k", CategoryName.SmallStraight),
                new Category("l", CategoryName.LargeStraight),
                new Category("m", CategoryName.FullHouse),
                new Category("n", CategoryName.Chance),
                new Category("o", CategoryName.Yatzy)
            };
        }
        public Category CheckIfCategoryUsed(Response response)
        {
            var chosenCategory = CategoryScoreCard.First(category => category.CategoryKey == response.Input.ToLower());
            return chosenCategory;
        }
    }
}