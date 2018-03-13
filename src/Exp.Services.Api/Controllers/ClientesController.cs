using System;
using Exp.Application.Interfaces;
using Exp.Domain.Interfaces.UoW;
using Exp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exp.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ClientesController : BaseController
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IUnitOfWork uow, IClienteService clienteService) : base(uow)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_clienteService.TrazerTodosAtivos());
        }

        [HttpPost]
        public IActionResult Post([FromBody]Cliente cliente)
        {
            var cl = _clienteService.Criar(cliente);
            Commit();
            return Response(_clienteService.Criar(cl));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Cliente cliente)
        {
            var cl = _clienteService.Atualizar(cliente);
            Commit();
            return Response(_clienteService.Criar(cl));
        }

        [HttpDelete("/api/[controller]/{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            return Response(_clienteService.Deletar(id));
        }

    }
}
