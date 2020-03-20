namespace YatzyKata
{
    public class Die : IDie
    {
        public int Result;

        private readonly IRng _rng;

        public Die(IRng rng)
        {
            _rng = rng;
            Result = rng.Next(1, 7);
        }

        public int RollDie()
        {
            Result = _rng.Next(1, 7);

            return Result;
        }
    }
}