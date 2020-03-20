using System;

namespace YatzyKata
{
    public interface IUserInput
    {
        Response GetResponse();
        bool GetRerollResponse();
        Response GetHoldResponse(String input);
        Response GetCategoryResponse(String input);
    }
}