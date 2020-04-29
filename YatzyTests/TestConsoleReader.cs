using System.Collections.Generic;
using YatzyKata;

namespace DiceTests
{
    public class TestConsoleReader : IConsoleReader
    {
        private readonly List<string> _userInputStrings;
        private int _index;

        public TestConsoleReader(string inputToReturn)
        {
            _userInputStrings = new List<string>(){inputToReturn};
        }

        public TestConsoleReader(List<string> userInputStrings)
        {
            _userInputStrings = userInputStrings;
        }

        public string GetInput() => _userInputStrings[_index++];
    }
}