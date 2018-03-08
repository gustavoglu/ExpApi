using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Interfaces.UoW;
using Exp.Domain.Models;
using System;
using System.Linq;

namespace Exp.Infra.Data.Inicializers
{
    public class ContaTipoInicializer
    {
        private readonly IContaTipoRepository _contaTipoRepository;
        private readonly IUnitOfWork _uow;

        public ContaTipoInicializer(IContaTipoRepository contaTipoRepository, IUnitOfWork uow)
        {
            _contaTipoRepository = contaTipoRepository;
            _uow = uow;
        }

        public void Seed()
        {
            var contaUsuarioExist = _contaTipoRepository.Pesquisar(ct => ct.Descricao == "Usuario").Count() > 0;
            if (contaUsuarioExist) return ;

            // Usuario
            ContaTipo contaTipo = new ContaTipo("Usuario");
            contaTipo.SetId(Guid.Parse("42c251fc-5e4b-4aee-9e92-f0159a2a6e65"));
            _contaTipoRepository.Criar(contaTipo);


            _uow.Commit();
        }
    }
}
