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
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("[" + die.Value + "]");
                Console.ResetColor();
            }
            Console.Write("\n\n");
        }

        public static void DisplayCategories(ScoreCard scoreCard, List<int> diceCup)
        {
            Console.Write("Categories:\n");

            foreach (var category in scoreCard.CategoryScoreCard)
            {
                if (category.IsUsed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(category.ToString());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{category.CategoryKey}) {category.CategoryName}: {ScoreCalculator.CalculateScore(diceCup, category.CategoryKey)}");
                }
            }
            Console.Write("\n");
        }

        public static void DisplayPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" > Press r to reroll");
            Console.WriteLine(" > Type values of dice to hold and reroll the cup (e.g. 3,1,4) ");
            Console.WriteLine(" > Type Category Key to score in that category (e.g. \"a\") ");
            Console.WriteLine(" > Press q to quit game");
            Console.ResetColor();

        }

        public static void NewRoundTitle()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNEW ROUND");
            Console.ResetColor();        
        }

        public static void WelcomeMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Yatzy");
            Console.ResetColor();
        }
    }
}