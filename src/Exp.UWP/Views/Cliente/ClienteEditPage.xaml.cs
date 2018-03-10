using Exp.Domain.Models;
using Exp.UWP.Views.Contato;
using Exp.UWP.Views.Endereco;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exp.UWP.Views.Cliente
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClienteEditPage : Page
    {
        public ClienteEditPage()
        {
            this.InitializeComponent();
            lv_contatos.ItemsSource = ContaCotatosMock();

        }

        ObservableCollection<ContaContato> ContaCotatosMock()
        {
            return new ObservableCollection<ContaContato>(
                new List<ContaContato>()
            {
                new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE"),
                new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE"),
                new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE"),
                new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE"),
                new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE"),
            });
        }
        private async void abb_novoEndereco_Click(object sender, RoutedEventArgs e)
        {
            ContaEnderecoContentDialog ce = new ContaEnderecoContentDialog();
            await ce.ShowAsync();
        }

        private async void abb_novoContato_Click(object sender, RoutedEventArgs e)
        {
            ContaContatoEditContentDialog cc = new ContaContatoEditContentDialog();
            await cc.ShowAsync();
        }

        private async void lv_contatos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var contaContato = e.ClickedItem as ContaContato;
            ContaContatoEditContentDialog cd = new ContaContatoEditContentDialog(contaContato);
            await cd.ShowAsync();
        }
    }
}
