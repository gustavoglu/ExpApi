using Exp.Application.Interfaces;
using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using System;
using System.Collections.Generic;

namespace Exp.Application.Services
{
    public class ContaTipoService : IContaTipoService
    {
        private readonly IContaTipoRepository _contaTipoRepository;
 
        public ContaTipoService(IContaTipoRepository contaTipoRepository)
        {
            _contaTipoRepository = contaTipoRepository;
        }

        public ContaTipo Atualizar(ContaTipo entity)
        {
            return _contaTipoRepository.Atualizar(entity);
        }

        public ContaTipo Criar(ContaTipo cliente)
        {
            return Criar(cliente);
        }

        public ContaTipo Deletar(Guid id)
        {
            return _contaTipoRepository.Deletar(id);
        }

        public ContaTipo TrazerPorId(Guid id)
        {
            return _contaTipoRepository.TrazerPorId(id);
        }

        public IEnumerable<ContaTipo> TrazerTodosAtivos()
        {
            return _contaTipoRepository.TrazerTodosAtivos();
        }

        public IEnumerable<ContaTipo> TrazerTodosDeletados()
        {
            return _contaTipoRepository.TrazerTodosDeletados();
        }
    }
}
