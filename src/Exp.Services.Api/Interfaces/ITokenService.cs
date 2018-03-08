using Exp.Infra.Identity.Models;

namespace Exp.Services.Api.Interfaces
{
    public interface ITokenService
    {
        object GetTokenUser(Usuario usuario);
    }
}
