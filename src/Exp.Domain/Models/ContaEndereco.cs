using Exp.Domain.Core.Models;
using System;

namespace Exp.Domain.Models
{
    public class ContaEndereco : Entity
    {
        public ContaEndereco(string rua, string numero, string complemento, string bairro, string cidade, string estado, string pais)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Rua { get; protected set; }
        public string Numero { get; protected set; }
        public string Complemento { get; protected set; }
        public string Bairro { get; protected set; }
        public string Cidade { get; protected set; }
        public string Estado { get; protected set; }
        public string Pais { get; protected set; }

        public Guid Id_conta { get; protected set; }

        public Conta Conta { get; set; }
    }
}
