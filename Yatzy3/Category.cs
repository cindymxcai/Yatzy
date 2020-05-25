namespace YatzyGame
{
    public class Category
    {
        public CategoryName CategoryName { get; }
        public string CategoryKey { get; }
        public int CategoryScore { get; set; }
        public bool IsUsed { get; set; }
        public override string ToString()
        {
            return $"{CategoryKey}) {CategoryName} : {CategoryScore}";
        }

        public Category(string key, CategoryName name)
        {
            IsUsed = false;
            CategoryScore = 0;
            CategoryName = name;
            CategoryKey = key;
        }
    }
}