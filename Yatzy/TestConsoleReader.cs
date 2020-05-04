using System.Collections.Generic;

namespace Yatzy
{
    public class TestConsoleReader : IConsoleReader
    {
        public List<string> InputString { get; }
        private int _index = 0;


        public TestConsoleReader(string inputString)
        {
            InputString = new List<string>{inputString};;
        }

        public TestConsoleReader(List<string> inputString)
        {
            InputString = inputString;
        }
        
            public string GetInput() => InputString[_index++];
        
    }
}