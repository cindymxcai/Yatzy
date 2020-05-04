using System;

namespace Yatzy
{
    public class RoundOverException : Exception
    {
        public RoundOverException(string message) : base(message)
        {
        }
    }
}