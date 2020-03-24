using System;

namespace YatzyKata
{
    public interface IUserInput
    {
        Response GetResponse();
        bool IsReroll(String input);
        Response GetHoldResponse(String input);
        Response GetCategoryResponse(String input);
    }
}