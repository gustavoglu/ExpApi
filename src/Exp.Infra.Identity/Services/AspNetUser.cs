using Exp.Domain.Interfaces.UserIdentity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Exp.Infra.Identity.Services
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool Logado()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> UserClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public string UserId()
        {
            return _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        }

        public string UserNameLogado()
        {
            return _accessor.HttpContext.User.Identity.Name;
        }
    }
}
