using Exp.Domain.Models;
using Exp.UWP.Handlers.Contatos;
using Exp.UWP.ViewModels;
using System;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exp.UWP.Views.Contatos
{
    public sealed partial class ContaContatoEditContentDialog : ContentDialog
    {
        private ContaContatoViewModel _contaContato;
        private string Titulo;
        private string TituloDialog;
        private bool _edit;
        public delegate void SalvaContato(object sender, ContaContatoHandler args);
        public event SalvaContato SalvaContatoHandler;

        public ContaContatoEditContentDialog(ContaContatoViewModel contato = null, bool edit = false)
        {
            AtribuiTituloDialog(contato);
            _contaContato = contato ?? new ContaContatoViewModel (new ContaContato(Guid.Empty));
            _edit = edit;
            this.InitializeComponent();
        }

        private void AtribuiTituloDialog(ContaContatoViewModel contato = null)
        {
            if (contato != null)
            {
                Titulo = $"Editar Contato {contato.Nome}";
                TituloDialog = "Editar Contato";
                return;
            }

            Titulo = "Novo Contato";
            TituloDialog = "Novo Contato";
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            SalvaContatoHandler(this, new ContaContatoHandler(_contaContato.ContaContato,_edit));
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
