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

namespace Exp.UWP.Views.Endereco
{
    public sealed partial class ContaEnderecoContentDialog : ContentDialog
    {
        private ContaEnderecoViewModel _contaEndereco;
        private string Titulo;
        private string TituloDialog;
        public ContaEnderecoContentDialog(ContaEnderecoViewModel contaEndereco = null)
        {
            AtribuiTituloDialog();
            _contaEndereco = contaEndereco ?? new ContaEnderecoViewModel( new ContaEndereco("","","","",""));
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
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
