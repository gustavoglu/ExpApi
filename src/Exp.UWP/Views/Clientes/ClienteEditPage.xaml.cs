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
        private ObservableCollection<ContaContatoViewModel> contatos;
        private ObservableCollection<ContaEnderecoViewModel> enderecos;
        private string[] TiposDocumento { get { return Enum.GetNames(typeof(ETipoDocumento)); } }
        ContaEnderecoContentDialog ce;
        public ClienteEditPage()
        {
            contatos = new ObservableCollection<ContaContatoViewModel>();
            enderecos = new ObservableCollection<ContaEnderecoViewModel>();

            this.InitializeComponent();

            lv_contatos.ItemsSource = contatos;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var cliente = e.Parameter as Cliente;
            _cliente = cliente;

            Edit = _cliente != null;
            if (!Edit)
            {
                var idTipoCliente = Guid.Parse("e8d735c4-a499-4ff3-9fdd-421c492dd543");
                _cliente = new Cliente("", idTipoCliente);
            }

            if (_cliente.Enderecos != null && _cliente.Enderecos.Any())
            {
                var enderecosViewModel = from endereco in _cliente.Enderecos
                                         select new ContaEnderecoViewModel(endereco);

                enderecos = new ObservableCollection<ContaEnderecoViewModel>(enderecosViewModel);
            }

            if (_cliente.Contatos != null && _cliente.Contatos.Any())
            {
                var contatosViewModel = from contato in _cliente.Contatos
                                        select new ContaContatoViewModel(contato);

                contatos = new ObservableCollection<ContaContatoViewModel>(contatosViewModel);
            }

        
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
            ce.SalvaEnderecoHandler += Ce_SalvaEnderecoHandler;
            await ce.ShowAsync();
        }

        private void Ce_SalvaEnderecoHandler(object sender, Handlers.Enderecos.ContaEnderecoHandler args)
        {
            if (!args.Edit)
                enderecos.Add(new ContaEnderecoViewModel(args.ContaEndereco));
            
        }

        private void Cc_SalvaContatoHandler(object sender, Handlers.Contatos.ContaContatoHandler args)
        {
            if (!args.Edit)
                contatos.Add(new ContaContatoViewModel(args.ContaContato));
        }

        private async void abb_novoContato_Click(object sender, RoutedEventArgs e)
        {
            ContaContatoEditContentDialog cc = new ContaContatoEditContentDialog();
            cc.SalvaContatoHandler += Cc_SalvaContatoHandler;
            await cc.ShowAsync();
        }
     
        private async void lv_contatos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var contaContato = e.ClickedItem as ContaContatoViewModel;
            ContaContatoEditContentDialog cc = new ContaContatoEditContentDialog(contaContato);
            cc.SalvaContatoHandler += Cc_SalvaContatoHandler;
            await cc.ShowAsync();
        }

        private async void abb_salvar_Click(object sender, RoutedEventArgs e)
        {
            if (contatos.Any()) _cliente.Contatos = contatos.ToList().Select(c => c.ContaContato);
            if (enderecos.Any()) _cliente.Enderecos = from endereco in enderecos.ToList() select endereco.ContaEndereco;

            WSService ws = new WSService();
            var result = await ws.Post(Constantes.SERVER_CLIENTES, _cliente);
        }

        private void abb_cancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void lv_enderecos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var endereco = e.ClickedItem as ContaEnderecoViewModel;
            ContaEnderecoContentDialog ce = new ContaEnderecoContentDialog(endereco);
            ce.SalvaEnderecoHandler += Ce_SalvaEnderecoHandler;
            await ce.ShowAsync();

        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
