using Exp.Domain.Models;
using System;

namespace Exp.UWP.Handlers.Enderecos
{
    public class ContaEnderecoHandler : EventArgs
    {
        public ContaEndereco ContaEndereco { get; private set; }
        public bool Edit { get; private set; }
  
        public ContaEnderecoHandler(ContaEndereco contaEndereco, bool edit = false)
        {
            ContaEndereco = contaEndereco;
            Edit = edit;
        }
    }
}
