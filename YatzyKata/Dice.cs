using System;
using System.Collections;

namespace DiceTests
{
    public interface IRng
    {
        int Next(int minValue, int maxValue);
    }
    
    public class Rng : IRng
    {
        private readonly Random _random;

        public Rng()
        {
            _random = new Random();
        }
        
        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }

    public class Dice : IDice
    {
        public static int Result;
        public bool IsHolding = false;

        private readonly IRng _rng;
        
        public Dice(IRng rng)
        {
            this._rng = rng;
        }
        
        public int RollDice()
        {
            if (!IsHolding)
            {
                Result = _rng.Next(1, 7);
            }
            return Result;

        }

        public bool HoldState
        {
            get { return IsHolding;}
            set { IsHolding = value; }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}