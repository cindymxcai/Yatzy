using System;

namespace YatzyKata
{
    public interface IUserInput
    {
        void GetResponseType();
        bool GetRerollResponse();
        void GetHoldResponse(String input);
        Category GetCategoryResponse(String input);
        Category ChosenCategory { get; set; }
    }
}