namespace YatzyKata
{
    public class CategoryScore
    {
        public Category Category { get; set; }
        public int Score { get; set; }

        public CategoryScore(Category category, int score)
        {
            Category = category;
            Score = score;
        }
    }
}