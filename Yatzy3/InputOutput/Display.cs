using System;
using System.Collections.Generic;
using System.Linq;
using YatzyGame.Scoring;

namespace YatzyGame.InputOutput
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

            Console.WriteLine();
        }

        public static void DisplayCategories(ScoreCard scoreCard, List<Die> diceCup)
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
                    Console.WriteLine(
                        $"{category.CategoryKey}) {category.CategoryName}: {ScoreCalculatorFactory.CreateCalculator(category, diceCup).Calculate()}");
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
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Welcome to Yatzy");
            Console.ResetColor();
        }

        public static void RollsLeft(int rollsLeft)
        {
            Console.WriteLine($"You have {rollsLeft} rolls left!\n");
        }

        public static void FinishedGame(ScoreCard scoreCard)
        {
            Console.WriteLine(
                $"You Finished Yatzy! Your total score was {scoreCard.CategoryScoreCard.Sum(category => category.CategoryScore)}");
        }
    }
}