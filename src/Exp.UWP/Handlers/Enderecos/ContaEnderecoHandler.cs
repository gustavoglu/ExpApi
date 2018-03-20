using Exp.Domain.Models;
using Exp.UWP.ViewModels;
using System;

namespace Exp.UWP.Handlers.Enderecos
{
    public class ContaEnderecoHandler : EventArgs
    {
        public ContaEnderecoViewModel ContaEnderecoViewModel { get; private set; }
        public ContaEndereco ContaEndereco { get { return ContaEnderecoViewModel.ContaEndereco; } }
        public bool Edit { get; private set; }

        public ContaEnderecoHandler(ContaEnderecoViewModel contaEnderecoViewModel, bool edit)
        {
            ContaEnderecoViewModel = contaEnderecoViewModel;
            Edit = edit;
        }
    }
}
