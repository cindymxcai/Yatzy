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
        [InlineData(new[] {true, true, false, false, true}, "e,b,a")][
        InlineData(new [] {false, false, false, true, false}, "D")]
        public void GetResponseShouldReturnHoldResponse(bool[] expectedDice, string userInputString)
        {
            var reader = new TestConsoleReader(userInputString);
            var userInput = new UserInput(reader);
            var expected = new Response(expectedDice);
            var actual = userInput.GetResponse();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(ResponseType.PlayerChoseReroll, "r")]
        [InlineData(ResponseType.PlayerChoseReroll, "R")]
        [InlineData(ResponseType.PlayerChoseDiceToHold, "b")]
        public void GetRerollResponseTest(ResponseType expectedType, string userInputString)
        {
            var reader = new TestConsoleReader(userInputString);
            var userInput = new UserInput(reader);
            var expected = new Response(expectedType);
            var actual = userInput.GetResponse();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQuitResponseTest()
        {
            var reader = new TestConsoleReader("Q");
            var userInput = new UserInput(reader);
            var expected = new Response(ResponseType.PlayerChoseQuit);
            var actual = userInput.GetResponse();
            Assert.Equal(expected, actual);
        }
        
        
        
    }
}