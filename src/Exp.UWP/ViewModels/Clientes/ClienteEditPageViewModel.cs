using System;
using System.Windows.Input;
using Exp.Domain.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Exp.UWP.ViewModels.Clientes
{
    public class ClienteEditPageViewModel : ClientePageViewModel
    {

        public ClienteEditPageViewModel(ClienteViewModel clienteViewModel) : base(clienteViewModel)
        {

        }

        protected override void DeletaContato(ContaContato contato)
        {
            throw new NotImplementedException();
        }

        protected override void DeletaEndereco(ContaEndereco endereco)
        {
            throw new NotImplementedException();
        }

        protected override void NovoContato()
        {
            Message.Aviso("teste");
        }

        protected override void NovoEndereco()
        {
            throw new NotImplementedException();
        }

        protected override void SalvarContato(ContaContato contato)
        {
            throw new NotImplementedException();
        }

        protected override void SalvarEndereco(ContaEndereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
