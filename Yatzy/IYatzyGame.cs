using System.Collections.Generic;

namespace Yatzy
{
    public interface IYatzyGame
    {
        List<Die> DiceCup { get; }
        void PlayRound();
    }
}