using System;
using System.Collections;
using DiceTests;

namespace YatzyKata
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

    public class Die : IDie
    {
        public  int Result;
        public  bool IsHolding = false;

        private readonly IRng _rng;
        
        public Die(IRng rng)
        {
            this._rng = rng;
            Result = rng.Next(1, 7);
        }
        
        public int RollDie()
        {
            if (!IsHolding)
            {
                Result = _rng.Next(1, 7);
            }
            return Result;

        }


    }
}