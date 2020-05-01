using System.Collections.Generic;

namespace Yatzy
{
    public class ScoreCard
    {
        private static readonly Category Ones = new Category();
        private static readonly Category Twos = new Category();
        private static readonly Category Threes = new Category();
        private static readonly Category Fours = new Category();
        private static readonly Category Fives = new Category();
        private static readonly Category Sixes = new Category();
        private static readonly Category Pairs = new Category();
        private static readonly Category TwoPairs = new Category();
        private static readonly Category ThreeOfAKind= new Category();
        private static readonly Category FourOfAKind = new Category();
        private static readonly Category SmallStraight = new Category();
        private static readonly Category LargeStraight = new Category();
        private static readonly Category FullHouse= new Category();
        private static readonly Category Chance = new Category();
        private static readonly Category Yatzy = new Category();

        public List<Category> CategoryScoreCard { get; } 

        public ScoreCard()
        {
            CategoryScoreCard = new List<Category>
            {
               Ones, Twos, Threes, Fours, Fives, Sixes, Pairs, TwoPairs, ThreeOfAKind, FourOfAKind, SmallStraight,
                LargeStraight, FullHouse, Chance, Yatzy
            };
            
            Ones.CategoryName = "Ones";
            Twos.CategoryName = "Twos";
            Threes.CategoryName = "Threes";
            Fours.CategoryName = "Fours";
            Fives.CategoryName = "Fives";
            Sixes.CategoryName = "Sixes";
            Pairs.CategoryName = "Pairs";
            TwoPairs.CategoryName = "Two Pairs";
            ThreeOfAKind.CategoryName = "Three Of A Kind";
            FourOfAKind.CategoryName = "Four Of A Kind";
            SmallStraight.CategoryName = "Small Straight";
            LargeStraight.CategoryName = "Large Straight";
            FullHouse.CategoryName = "Full House";
            Chance.CategoryName = "Chance";
            Yatzy.CategoryName = "Yatzy";
        }


        
    }
}