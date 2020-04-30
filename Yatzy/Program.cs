namespace Yatzy
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var consoleReader = new ConsoleReader();
            var player = new Player(consoleReader);
            var yatzy = new YatzyGame(player);
            yatzy.PlayRound();
        }
    }
}