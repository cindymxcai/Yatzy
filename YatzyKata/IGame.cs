using System.Collections.Generic;

namespace YatzyKata
{
    public interface IGame
    {
        IEnumerable<int> GetValues();
        void DisplayRoll();
        void RollDice();
        void Hold(bool[] bools);
        void StoreScore(Category category, int score);
        void PromptAction();
        void DisplayCategories();
    }
}