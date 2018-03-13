using Exp.Application.Interfaces;
using Exp.Domain.Interfaces.UoW;
using Exp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exp.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ContaTiposController : BaseController
    {
        private readonly IContaTipoService _contaTipoService;
        public ContaTiposController(IUnitOfWork uow, IContaTipoService contaTipoService) : base(uow)
        {
            _contaTipoService = contaTipoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_contaTipoService.TrazerTodosAtivos());
        }

        [HttpPost]
        public IActionResult Post([FromBody]ContaTipo contaTipo)
        {
            var ct = _contaTipoService.Criar(contaTipo);
            Commit();
            return Response(ct);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ContaTipo contaTipo)
        {
            var ct = _contaTipoService.Atualizar(contaTipo);
            Commit();
            return Response(ct);
        }

        [HttpDelete("/api/[controller]/{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var ct = _contaTipoService.Deletar(id);
            Commit();
            return Response();
        }
    }
}
