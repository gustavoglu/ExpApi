using Exp.Domain.Models;
using Exp.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exp.UWP.Views.Contato
{
    public sealed partial class ContaContatoEditContentDialog : ContentDialog
    {
        private ContaContatoViewModel _contaContato;
        private string Titulo;
        private string TituloDialog;
        public ContaContatoEditContentDialog(ContaContatoViewModel contato = null)
        {
            AtribuiTituloDialog(contato);

            _contaContato = contato ??new ContaContatoViewModel (new ContaContato(Guid.Empty));

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
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
