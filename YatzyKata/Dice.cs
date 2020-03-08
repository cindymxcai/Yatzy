using System;
using System.Collections.Generic;

namespace DiceTests
{
    public class Dice
    {
        private int _result;
        public bool _isHolding = false;
        
        public int RollDice()
        {
            if (!_isHolding)
            {
                Random random = new Random();
                _result = random.Next(1, 7);
            }
            return _result;

        }

        public bool HoldState
        {
            get { return _isHolding;}
            set { _isHolding = value; }
        }

    }
}