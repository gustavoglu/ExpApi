using Exp.Infra.Identity.Models;
using Exp.Infra.Identity.ViewModels;
using Exp.Services.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exp.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ITokenService _tokenService;

        public UsuarioController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [Route("/api/[controller]/registro")]
        public async Task<IActionResult> Registro([FromBody]NovoUsuarioViewModel novoUsuario)
        {
            if (!ModelState.IsValid)
                return Response();

            Usuario usuario = new Usuario() { UserName = novoUsuario.Login, Email = novoUsuario.Login };

            var resultIdentity = await _userManager.CreateAsync(usuario, novoUsuario.Senha);

            AddErrosIdentity(resultIdentity);

            if (!resultIdentity.Succeeded) return Response();

            var tokenObject = _tokenService.GetTokenUser(usuario);

            return Response(tokenObject);
        }

        [Route("/api/[controller]/login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel login)
        {
            if (!ModelState.IsValid) return Response();
            var usuario = await _userManager.FindByNameAsync(login.Login);

            if (usuario == null)
            {
                ModelState.AddModelError("Usuario", "usuario não encontrado");
                return Response();
            }

            var result = await _signInManager.PasswordSignInAsync(login.Login, login.Senha, false, false);

            if (!result.Succeeded)
            { 
                ModelState.AddModelError("Usuario", "Não foi possivel se logar, verifique seu usuario e senha e tente novamente.");
                return Response();
            }

            var tokenObject = _tokenService.GetTokenUser(usuario);

            return Response(tokenObject);
        }

        private void AddErrosIdentity(IdentityResult identityResult)
        {
            if (identityResult.Succeeded) return;
            foreach (var erro in identityResult.Errors)
                ModelState.AddModelError("Identity", erro.Description);
        }

 
    }
}

