using Exp.Domain.Core.Models;
using Exp.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Exp.Domain.Models
{
    public abstract class Conta : Entity
    {
        public Conta()
        {

        }
        protected Conta(string nome ,Guid id_contaTipo,string email = null, string telefone = null, string telefoneAdicional = null, string documento = null, ETipoDocumento? tipoDocumento = null)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TelefoneAdicional = telefoneAdicional;
            Documento = documento;
            TipoDocumento = tipoDocumento;
            Id_contaTipo = id_contaTipo;
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string TelefoneAdicional { get; set; } 

        public string Documento { get; set; }

        public ETipoDocumento? TipoDocumento { get; set; }

        public Guid Id_contaTipo { get; set; }

        public ContaTipo ContaTipo { get; set; }

        public IEnumerable<ContaEndereco> Enderecos { get; set; }

        public IEnumerable<ContaContato> Contatos { get; set; }
    }
}
