using Exp.Domain.Core.Models;
using Exp.Domain.Enums;
using Exp.Domain.Models;
using Exp.UWP.ViewModels;
using Exp.UWP.Views.Contatos;
using Exp.UWP.Views.Endereco;
using Exp.UWP.WS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace Exp.UWP.Views.Clientes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClienteEditPage : Page
    {
        Cliente _cliente;
        private bool Edit = false;
        private string[] TiposDocumento { get { return Enum.GetNames(typeof(ETipoDocumento)); } }
        public ClienteEditPage()
        {
            this.InitializeComponent();
            lv_contatos.ItemsSource = ContaCotatosMock();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var cliente = e.Parameter as Cliente;
            _cliente = cliente;

            if (_cliente != null)
            {
                Edit = true;
                return;
            };

            var idTipoCliente = Guid.Parse("e8d735c4-a499-4ff3-9fdd-421c492dd543");
            _cliente = new Cliente("", idTipoCliente);

            base.OnNavigatedTo(e);
        }


        private async Task<List<ContaTipo>> TrazerContaTipos()
        {
            WSService ws = new WSService();
            var contaTipos = await ws.Get<List<ContaTipo>>(Constantes.SERVER_CONTATIPOS);
            if (contaTipos.GetType() == typeof(Response))
            {
                var response = (Response)contaTipos;
                Message.Erro((string)response.Data);
                return null;
            }
            return (contaTipos as List<ContaTipo>);
        }

        ObservableCollection<ContaContatoViewModel> ContaCotatosMock()
        {
            return new ObservableCollection<ContaContatoViewModel>(
                new List<ContaContatoViewModel>()
            {
                new ContaContatoViewModel( new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE")),
                new ContaContatoViewModel( new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE")),
                new ContaContatoViewModel( new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE")),
                new ContaContatoViewModel( new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE")),
                new ContaContatoViewModel( new ContaContato(Guid.Empty,"TESTE","TESTE","TESTE","TESTE","TESTE","TESTE")),
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
            var contaContato = e.ClickedItem as ContaContatoViewModel;
            ContaContatoEditContentDialog cd = new ContaContatoEditContentDialog(contaContato);
            await cd.ShowAsync();
        }

        private async void abb_salvar_Click(object sender, RoutedEventArgs e)
        {
            if (_cliente.TipoDocumento == null) return;
            WSService ws = new WSService();
            var result = await ws.Post(Constantes.SERVER_CLIENTES, _cliente);
        }

        private void abb_cancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
