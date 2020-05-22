using YatzyGame.InputOutput;

namespace YatzyGame
{
    public static class Program
    {
        public static void Main(string[] args)
            {
                var consoleReader = new ConsoleReader();
                var player = new Player(consoleReader);
                var scoreCard = new ScoreCard();
                var rng = new Rng();
                var yatzy = new Game(player, scoreCard, rng);
                Display.WelcomeMessage();
                yatzy.PlayGame();
            }
    }
}