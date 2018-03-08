namespace Exp.Services.Api.Models
{
    public class Response
    {
        public Response(object data = null, bool success = false)
        {
            Data = data;
            Success = success;
        }

        public object Data { get; private set; }
        public bool Success { get; private set; }
    }
}
