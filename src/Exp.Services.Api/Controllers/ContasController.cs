using System;
using Exp.Application.Interfaces;
using Exp.Domain.Interfaces.UoW;
using Exp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exp.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContasController : BaseController
    {
        private readonly IContaService _contaService;
        public ContasController(IUnitOfWork uow, IContaService contaService) : base(uow)
        {
            _contaService = contaService;
        }


        [HttpPost("/api/[controller]/Endereco")]
        public IActionResult CriaEnderecoConta([FromBody]ContaEndereco contaEndereco)
        {
            if (contaEndereco.Id_conta == null || contaEndereco.Id_conta == Guid.Empty)
            {
                ModelState.AddModelError("Endereco", "É Obrigatório informar a conta");
                return Response(null);
            }

            _contaService.AtruibuiEnderecoConta(contaEndereco);

            if (!Commit()) return Response(null);

            return Response(contaEndereco);
        }

        [HttpPut("/api/[controller]/Endereco")]
        public IActionResult AtualizaEnderecoConta([FromBody]ContaEndereco contaEndereco)
        {
            if (contaEndereco.Id_conta == null || contaEndereco.Id_conta == Guid.Empty)
            {
                ModelState.AddModelError("Contato", "É Obrigatório informar a conta");
                return Response(null);
            }

            _contaService.AtualizaEnderecoConta(contaEndereco);

            if (!Commit()) return Response(null);

            return Response(contaEndereco);
        }

        [HttpDelete("/api/[controller]/Endereco/{id_endereco:Guid}")]
        public IActionResult RemoveEnderecoConta(Guid id_endereco)
        {
            if (id_endereco == null || id_endereco == Guid.Empty)
            {
                ModelState.AddModelError("Contato", "É Obrigatório informar o endereco");
                return Response(null);
            }

            _contaService.RemoveEnderecoConta(id_endereco);

            if (!Commit()) return Response(null);

            return Response(true);
        }

        [HttpPost("/api/[controller]/Contato")]
        public IActionResult CriaContatoConta([FromBody]ContaContato contaContato)
        {
            if (contaContato.Id_conta == null || contaContato.Id_conta == Guid.Empty)
            {
                ModelState.AddModelError("Contato", "É Obrigatório informar a conta");
                return Response(null);
            }

            _contaService.AtualizaContatoConta(contaContato);

            if (!Commit()) return Response(null);

            return Response(contaContato);
        }

        [HttpPut("/api/[controller]/Contato")]
        public IActionResult AtualizaContatoConta([FromBody]ContaContato contaContato)
        {
            if (contaContato.Id_conta == null || contaContato.Id_conta == Guid.Empty)
            {
                ModelState.AddModelError("Contato", "É Obrigatório informar a conta");
                return Response(null);
            }

            _contaService.AtualizaContatoConta(contaContato);

            if (!Commit()) return Response(null);

            return Response(contaContato);
        }

        [HttpDelete("/api/[controller]/Contato/{id_contato:Guid}")]
        public IActionResult RemoveContatoConta(Guid id_contato)
        {
            if (id_contato == null || id_contato == Guid.Empty)
            {
                ModelState.AddModelError("Contato", "É Obrigatório informar o contato");
                return Response(null);
            }

            _contaService.RemoveContatoConta(id_contato);

            if (!Commit()) return Response(null);

            return Response(true);
        }
    }
}
