using Exp.Domain.Core.Models;
using System;

namespace Exp.Domain.Models
{
    public class ContaEndereco : Entity
    {
        private ContaEndereco()
        {

        }

        public ContaEndereco(string rua , string numero, string bairro, string cidade, string estado, string complemento = null,string pais = null)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public Guid Id_conta { get; protected set; }

        public Conta Conta { get; set; }
    }
}
