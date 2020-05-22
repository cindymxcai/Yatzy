using System;

namespace YatzyGame.InputOutput
{
    public class ConsoleReader : IConsoleReader
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}