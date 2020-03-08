using System;
using System.Collections;
using System.Collections.Generic;

namespace DiceTests
{
    public class Dice 
    {
        public static int _result;
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

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}