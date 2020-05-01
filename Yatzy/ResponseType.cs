using System;
using System.Linq;

namespace Yatzy
{
    public enum ResponseType
    {
        QuitGame,
        HoldDice,
        RerollDice,
        ScoreInCategory
        
    }

    public class Response
    {
        public readonly ResponseType ResponseType;

        public Response()
        {
            
        }
        public Response(ResponseType chosenResponseType)
        {
            ResponseType = chosenResponseType;
        }
        
        

    }

}