using Exp.Application.Interfaces;
using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using System;

namespace Exp.Application.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaEnderecoRepository _contaEnderecoRepository;
        private readonly IContaContatoRepository _contaContatoRepository;

        public ContaService(IContaEnderecoRepository contaEnderecoRepository, IContaContatoRepository contaContatoRepository)
        {
            _contaEnderecoRepository = contaEnderecoRepository;
            _contaContatoRepository = contaContatoRepository;
        }

        public void AtruibuiContatoConta(ContaContato contaContato)
        {
            _contaContatoRepository.Criar(contaContato);
        }

        public void AtruibuiEnderecoConta(ContaEndereco contaEndereco)
        {
            _contaEnderecoRepository.Criar(contaEndereco);
        }

        public void AtualizaContatoConta(ContaContato contaContato)
        {
            _contaContatoRepository.Atualizar(contaContato);
        }

        public void AtualizaEnderecoConta(ContaEndereco contaEndereco)
        {
            _contaEnderecoRepository.Atualizar(contaEndereco);
        }

        public void RemoveContatoConta(Guid id_contato)
        {
            _contaContatoRepository.Deletar(id_contato);
        }

        public void RemoveEnderecoConta(Guid id_endereco)
        {
            _contaEnderecoRepository.Deletar(id_endereco);
        }
    }
}
