using Matchmaking.Shared.Responses.Enums;

namespace Matchmaking.Shared.Responses
{
    public class MatchmakingResponse
    {
        public ResponseCode Code { get; private set; }
        public string Message { get; private set; }
        public object? Data { get; private set; }

        public MatchmakingResponse(
            ResponseCode responseCode,
            string message,
            object? data)
        {
            Code = responseCode;
            Message = message;
            Data = data;       
        }

        public MatchmakingResponse()
        {
            Code = ResponseCode.None;
            Message = string.Empty;
            Data = null;       
        }
    }    
}

