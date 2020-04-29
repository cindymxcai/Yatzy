namespace Yatzy
{
    public class Die
    {
        public int Value { get; set; }
        public void Roll(IRng rng )
        {
            Value =  rng.Next(1, 7);
        }
    }
}