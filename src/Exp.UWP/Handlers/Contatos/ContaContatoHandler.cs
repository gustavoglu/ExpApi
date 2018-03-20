using Exp.Domain.Models;
using Exp.UWP.ViewModels;
using System;

namespace Exp.UWP.Handlers.Contatos
{
    public class ContaContatoHandler : EventArgs
    {
        public ContaContato ContaContato { get { return ContaContatoViewModel.ContaContato; } }
        public ContaContatoViewModel ContaContatoViewModel{ get; set; }
        public bool Edit { get; private set; }

        public ContaContatoHandler(ContaContatoViewModel contaContatoViewModel, bool edit = false)
        {
            ContaContatoViewModel = contaContatoViewModel;
            Edit = edit;
        }
    }
}
