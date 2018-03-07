using System;
using Exp.Domain.Enums;

namespace Exp.Domain.Models
{
    public class Colaborador : Conta
    {
        public Colaborador(string nome, Guid id_contaTipo, string sobrenome = null, string departamento = null, string funcao = null,string email = null, 
            string telefone = null, string telefoneAdicional = null, string documento = null, ETipoDocumento? tipoDocumento = null) : 
            base(nome, id_contaTipo, email, telefone, telefoneAdicional, documento, tipoDocumento)
        {
            Sobrenome = sobrenome;
            Departamento = departamento;
            Funcao = funcao;
        }

        public string Sobrenome { get; protected set; }

        public string Departamento { get; protected set; }

        public string Funcao { get; protected set; }

        public Guid? Id_cliente{ get; protected set; }

        public Cliente Cliente { get; set; }
    }
}
