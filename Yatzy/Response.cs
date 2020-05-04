namespace Yatzy
{
    public class Response
    {
        public ResponseType ResponseType1 { get; }
        public string Input { get; }

        public Response(ResponseType chosenResponseType) 
        {
            ResponseType1 = chosenResponseType;
        }
        
        public Response(ResponseType chosenResponseType, string input)
        {
            ResponseType1 = chosenResponseType;
            Input = input;
        }
        
    }
}