using Exp.Domain.Core.Models;
using System;

namespace Exp.Domain.Models
{
    public class ContaContato : Entity
    {
        public ContaContato()
        {

        }
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

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string TelefoneAdicional { get; set; }
        public string Email { get; set; }
        public string Funcao { get; set; }
        public string Observacoes { get; set; }
        public Guid Id_conta { get; set; }

        public Conta Conta { get; set; }
    }
}
