using System;

namespace Yatzy
{
    public class Response
    {
        public ResponseType ResponseType;
        public string Input;

        public Response()
        {
            
        }
        
        public Response(ResponseType chosenResponseType) 
        {
            ResponseType = chosenResponseType;
        }
        
        public Response(ResponseType chosenResponseType, string input)
        {
            ResponseType = chosenResponseType;
            Input = input;
        }
        
    }
}