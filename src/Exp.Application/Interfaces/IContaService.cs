using Exp.Domain.Models;
using System;

namespace Exp.Application.Interfaces
{
    public interface IContaService
    {
        void AtruibuiEnderecoConta(ContaEndereco contaEndereco);
        void AtualizaEnderecoConta(ContaEndereco contaEndereco);
        void AtruibuiContatoConta(ContaContato contaContato);
        void AtualizaContatoConta(ContaContato contaContato);
        void RemoveEnderecoConta(Guid id_endereco);
        void RemoveContatoConta(Guid id_contato);
    }
}
