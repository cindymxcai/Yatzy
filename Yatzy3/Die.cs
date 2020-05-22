namespace YatzyGame
{
    public class Die
    {
        public int Value { get;  set; }

        public bool IsHeld { get; set; } 
        public void Roll(IRng rng )
        {
            Value =  rng.Next(1, 7);
        }
    }
}