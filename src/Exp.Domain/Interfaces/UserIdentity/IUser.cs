using System.Collections.Generic;
using System.Security.Claims;

namespace Exp.Domain.Interfaces.UserIdentity
{
    public interface IUser
    {
        string UserNameLogado();
        bool Logado();
        string UserId();
        IEnumerable<Claim> UserClaims();
    }
}
