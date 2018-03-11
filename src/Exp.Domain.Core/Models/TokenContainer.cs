namespace Exp.Domain.Core.Models
{
    public class TokenContainer
    {
        public TokenContainer()
        {
                
        }
        public TokenContainer(string created, string expiration, string accessToken, string userId)
        {
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            UserId = userId;
        }

        public string Created { get; set; }
        public string Expiration{ get; set; }
        public string AccessToken { get; set; }
        public string UserId { get; set; }
    }
}
