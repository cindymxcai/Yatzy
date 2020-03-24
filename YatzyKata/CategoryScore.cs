using System;

namespace YatzyKata
{
    public class CategoryScore : ICategoryScore
    {
        public Category Category { get; set; }
        public int Score { get; set; }

        public CategoryScore(Category category, int score)
        {
            Category = category;
            Score = score;
        }

        private bool Equals(ICategoryScore other)
        {
            return Category == other.Category && Score == other.Score;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CategoryScore) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) Category, Score);
        }
    }
}