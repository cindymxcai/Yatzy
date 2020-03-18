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

        public void GetHoldResponse()
        {
           var input = Console.ReadLine();

            string[] holdDice = input?.Split(',');

            if (holdDice != null)
                foreach (var letter in holdDice)
                {
                    if (letter == "a" || letter == "A")
                    {
                        Game.CurrentlyHolding[0] = true;
                    }

                    if (letter == "b" || letter == "B")
                    {
                        Game.CurrentlyHolding[1] = true;
                    }

                    if (letter == "c" || letter == "C")
                    {
                        Game.CurrentlyHolding[2] = true;
                    }

                    if (letter == "d" || letter == "D")
                    {
                        Game.CurrentlyHolding[3] = true;
                    }

                    if (letter == "e" || letter == "E")
                    {
                        Game.CurrentlyHolding[4] = true;
                    }
                }
        }
        
        public Category GetCategoryResponse()
        {

            var input = Console.ReadLine();

            Category chosenCategory = Category.None;
            
            if (int.Parse(input) == 1)
            {
                chosenCategory = Category.Ones;
            }
            if (int.Parse(input) == 2)
            {
                chosenCategory = Category.Twos;
            }
            if (int.Parse(input) == 3)
            {
                chosenCategory = Category.Threes;
            }
            if (int.Parse(input) == 4)
            {
                chosenCategory = Category.Fours;
            }
            if (int.Parse(input) == 5)
            {
                chosenCategory = Category.Fives;
            }
            if (int.Parse(input) == 6)
            {
                chosenCategory = Category.Sixes;
            }
            

            return chosenCategory;
        }
        
    }
}