using System;

namespace YatzyKata
{
    public class ConsoleReader : IConsoleReader
    {
        public string getInput()
        {
            return Console.ReadLine();
        }
    }
}