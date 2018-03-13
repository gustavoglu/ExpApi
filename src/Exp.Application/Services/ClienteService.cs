using Exp.Application.Interfaces;
using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using System;
using System.Collections.Generic;

namespace Exp.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public Cliente Criar(Cliente cliente)
        {
            return _clienteRepository.Criar(cliente);
        }

        public Cliente Deletar(Guid id)
        {
            return _clienteRepository.Deletar(id);
        }

        public Cliente TrazerPorId(Guid id)
        {
            return _clienteRepository.TrazerPorId(id);
        }

        public IEnumerable<Cliente> TrazerTodosAtivos()
        {
            return _clienteRepository.TrazerTodosAtivos();
        }

        public IEnumerable<Cliente> TrazerTodosDeletados()
        {
            return _clienteRepository.TrazerTodosDeletados();
        }
    }
}
