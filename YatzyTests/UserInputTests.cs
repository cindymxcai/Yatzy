using Xunit;
using YatzyKata;

namespace DiceTests
{
    public class UserInputTests
    {
        [Fact]
        public void GetResponseTypeTest(  )
        {
            var reader = new TestConsoleReader("1");
            var userInput = new UserInput(reader);
            var expected = new Response(Category.Ones);
            var actual = userInput.GetResponse();
            Assert.Equal(expected, actual);
        }
        

        private class TestConsoleReader : IConsoleReader
        {
            private readonly string _inputToReturn;

            public TestConsoleReader(string inputToReturn)
            {
                _inputToReturn = inputToReturn;

            }
            public string GetInput()
            {
                return _inputToReturn;
            }
        }

    }
}