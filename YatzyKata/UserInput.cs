using System;

namespace YatzyKata
{
    public class UserInput : IUserInput
    {
        public bool GetRerollResponse()
        {
            var input = Console.ReadLine();

            if (input == "R" || input == "r")
            {
                return true;
            }

            return false;
        }

        public bool getHoldResponse()
        {
            throw new NotImplementedException();
        }
    }
}