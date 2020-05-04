namespace Yatzy
{
    public class Category
    {
        public string CategoryName { get;}
        public string CategoryKey { get; }
        public int CategoryScore { get; set; }
        public bool IsUsed { get; set; } 

        public override string ToString()
        {
            return $"{CategoryKey}) {CategoryName} : {CategoryScore}";
        }

        public Category(string key, string name)
        {
            IsUsed = false;
            CategoryScore = 0;
            CategoryName = name;
            CategoryKey = key;
        }
    }
}