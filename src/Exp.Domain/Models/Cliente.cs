using System;
using System.Collections.Generic;
using Exp.Domain.Enums;

namespace Exp.Domain.Models
{
    public class Cliente : Conta
    {
        protected Cliente(string nome, Guid id_contaTipo, string razaoSocial = null, string email = null, string telefone = null, string telefoneAdicional = null, 
            string documento = null, ETipoDocumento? tipoDocumento = null) : 
            base(nome, id_contaTipo, email, telefone, telefoneAdicional, documento, tipoDocumento)
        {
            RazaoSocial = razaoSocial;
        }

        public string RazaoSocial { get; protected set; }

        public IEnumerable<Colaborador> Colaboradores { get; set; }
    }
}
