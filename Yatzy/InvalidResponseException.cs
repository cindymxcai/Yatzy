using System;

namespace Yatzy
{
    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message): base(message)
        {
        }
    }
}