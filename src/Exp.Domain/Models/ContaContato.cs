using Exp.Domain.Core.Models;
using System;

namespace Exp.Domain.Models
{
    public class ContaContato : Entity
    {
        public ContaContato(Guid id_conta, string nome = null, string telefone = null, string telefoneAdicional = null, string email = null, string funcao = null, string observacoes = null)
        {
            Nome = nome;
            Telefone = telefone;
            TelefoneAdicional = telefoneAdicional;
            Email = email;
            Funcao = funcao;
            Observacoes = observacoes;
            Id_conta = id_conta;
        }

        public string Nome { get; protected set; }
        public string Telefone { get; protected set; }
        public string TelefoneAdicional { get; protected set; }
        public string Email { get; protected set; }
        public string Funcao { get; protected set; }
        public string Observacoes { get; protected set; }
        public Guid Id_conta { get; protected set; }

        public Conta Conta { get; set; }
    }
}
