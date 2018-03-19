using Exp.Domain.Models;
using System;

namespace Exp.UWP.Handlers.Contatos
{
    public class ContaContatoHandler : EventArgs
    {
        public ContaContato ContaContato { get; private set; }
        public bool Edit { get; private set; }

        public ContaContatoHandler(ContaContato contaContato, bool edit = false)
        {
            ContaContato = contaContato;
            Edit = edit;
        }
    }
}
