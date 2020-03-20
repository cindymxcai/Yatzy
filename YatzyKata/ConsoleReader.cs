using System;

namespace YatzyKata
{
    public class ConsoleReader : IConsoleReader
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}