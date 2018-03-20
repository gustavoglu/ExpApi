using Exp.Domain.Models;
using Exp.UWP.Handlers.Enderecos;
using Exp.UWP.ViewModels;
using System;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exp.UWP.Views.Endereco
{
    public sealed partial class ContaEnderecoContentDialog : ContentDialog
    {
        private ContaEnderecoViewModel _contaEndereco;
        private string Titulo;
        private string TituloDialog;
        private bool _edit;
        public delegate void SalvaEndereco(object sender, ContaEnderecoHandler args);
        public event SalvaEndereco SalvaEnderecoHandler;

        public ContaEnderecoContentDialog(ContaEnderecoViewModel contaEndereco = null, bool edit = false)
        {
            AtribuiTituloDialog();
            _contaEndereco = contaEndereco ?? new ContaEnderecoViewModel(new ContaEndereco("" ,"","","",""));
            _edit = edit;
            _contaEndereco.BeginEdit();
            this.InitializeComponent();
        }

        private void AtribuiTituloDialog(ContaEndereco contaEndereco = null)
        {
            if (contaEndereco != null)
            {
                Titulo = $"Editar Endereço";
                TituloDialog = "Editar Endereço";
                return;
            }

            Titulo = "Novo Endereço";
            TituloDialog = "Novo Endereço";
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            SalvaEnderecoHandler(this, new ContaEnderecoHandler(_contaEndereco, _edit));
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
