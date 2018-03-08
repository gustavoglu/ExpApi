using Exp.Application.ViewModels;
using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Interfaces.UoW;
using Exp.Domain.Models;
using Exp.Infra.Identity.Models;
using Exp.Infra.Identity.ViewModels;
using Exp.Services.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IColaboradorRepository _colaboradorRepository;

        public UsuarioController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, ITokenService tokenService, IColaboradorRepository colaboradorRepository, IUnitOfWork uow) : base(uow)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _colaboradorRepository = colaboradorRepository;
        }

        [Route("/api/[controller]/registro")]
        public async Task<IActionResult> Registro([FromBody]RegistroViewModel registroViewModel)
        {
            if (registroViewModel == null) return Response();

            if (!ModelState.IsValid)
                return Response();

            Usuario usuario = new Usuario() { UserName = registroViewModel.Login, Email = registroViewModel.Login };

            var guidContaTipoUsuario = Guid.Parse("42c251fc-5e4b-4aee-9e92-f0159a2a6e65");
            Colaborador colaborador = new Colaborador(registroViewModel.Nome, guidContaTipoUsuario, registroViewModel.Sobrenome,
                null, null, registroViewModel.Login, registroViewModel.Telefone, registroViewModel.TelefoneAdicional, registroViewModel.Documento,
                registroViewModel.TipoDocumento);

            var resultIdentity = await _userManager.CreateAsync(usuario, registroViewModel.Senha);

            AddErrosIdentity(resultIdentity);

            if (!resultIdentity.Succeeded) return Response();

            colaborador.SetId(Guid.Parse(usuario.Id));
            _colaboradorRepository.Criar(colaborador);

            var resultCommit = Commit();

            if (!resultCommit)
            {
                var usuarioCriado = await _userManager.FindByIdAsync(usuario.Id);
                await _userManager.DeleteAsync(usuarioCriado);
            }

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

