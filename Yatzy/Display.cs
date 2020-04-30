using System;
using System.Collections.Generic;

namespace Yatzy
{
    public static class Display
    {
        public static void DisplayDice(IEnumerable<Die> diceCup)
        {
            Console.WriteLine("Your current roll is:");
            foreach (var die in diceCup)
            {
                Console.Write("[" + die.Value + "]");
            }
            Console.Write("\n");
        }
    }
}