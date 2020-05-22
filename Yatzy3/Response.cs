namespace YatzyGame
{
    public class Response
    {
        public ResponseType ResponseType { get; set; }
        public string Input { get; }

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