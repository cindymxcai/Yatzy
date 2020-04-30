using System;

namespace Yatzy
{
    public class ConsoleReader : IConsoleReader
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}