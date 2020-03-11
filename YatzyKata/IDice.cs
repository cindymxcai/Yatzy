using System.Collections;

namespace DiceTests
{
    public interface IDice
    {
        int RollDice();
        bool HoldState { get; set; }
        IEnumerator GetEnumerator();
    }
}