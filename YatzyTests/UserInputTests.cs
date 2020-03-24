using System;
using System.Collections.Generic;
using Xunit;
using YatzyKata;

namespace DiceTests
{
    public class UserInputTests
    {
        [Theory]
        [InlineData(Category.Ones, "1")]
        [InlineData(Category.Twos, "2")]
        [InlineData(Category.Threes, "3")]
        [InlineData(Category.Yatzy, "15")]
        [InlineData(Category.None, "a")]
        public void GetResponseShouldReturnCategoryResponse(Category expectedCategory, string userInputString)
        {
            var reader = new TestConsoleReader(userInputString);
            var userInput = new UserInput(reader);
            var expected = new Response(expectedCategory);
            var actual = userInput.GetResponse();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {true, false, false, false, false}, "a")]
        [InlineData(new[] {false, false, true, false, false}, "c")]
        [InlineData(new[] {false, true, false, false, false}, "B")]
        [InlineData(new[] {true, true, false, false, false}, "a,b")]
        [InlineData(new[] {true, true, false, false, true}, "a,b,e")]
        [InlineData(new[] {true, true, false, false, true}, "e,b,a")]
        public void GetResponseShouldReturnHoldResponse(bool[] expectedDice, string userInputString)
        {
            var reader = new TestConsoleReader(userInputString);
            var userInput = new UserInput(reader);
            var expected = new Response(expectedDice);
            var actual = userInput.GetResponse();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, "r")]
        [InlineData(true, "R")]
        [InlineData(false, "b")]
        public void GetRerollResponseTest(bool expectedBool, string userInputString)
        {
            var reader = new TestConsoleReader(userInputString);
            var userInput = new UserInput(reader);
            var expected = new Response(expectedBool);
            var actual = userInput.GetResponse();
            Assert.Equal(expected, actual);
        }
        
    }
    
    public class TestConsoleReader : IConsoleReader
    {
        private readonly List<string> _userInputStrings;
        private readonly string _inputToReturn;
        private int _index = 0;

        public TestConsoleReader(string inputToReturn)
        {
            _userInputStrings = new List<string>(){inputToReturn};
        }

        public TestConsoleReader(List<string> userInputStrings)
        {
            _userInputStrings = userInputStrings;
        }

        public string GetInput()
        {
            return _userInputStrings[_index++];
        }
    }
}