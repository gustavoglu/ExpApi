using Exp.Domain.Core.Models;
using Exp.Domain.Enums;
using Exp.Domain.Models;
using Exp.UWP.EntityServices;
using Exp.UWP.ViewModels;
using Exp.UWP.ViewModels.Clientes;
using Exp.UWP.Views.Contatos;
using Exp.UWP.Views.Endereco;
using Exp.UWP.WS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public sealed partial class ClienteEditPage : Page, INotifyPropertyChanged
    {
        public ClienteEditPage()
        {
            this.InitializeComponent();
        }

        private bool edit;

        public bool Edit
        {
            get { return edit; }
            set { edit = value; Notify(); }
        }

        private ClienteViewModel clienteViewModel;

        private ClienteViewModel ClienteViewModel
        {
            get { return clienteViewModel; }
            set { clienteViewModel = value; Notify(); }
        }

        private ObservableCollection<ContaContatoViewModel> contatos;
        private ObservableCollection<ContaContatoViewModel> Contatos
        {
            get { return contatos; }
            set { contatos = value; Notify(); }
        }

        private ObservableCollection<ContaEnderecoViewModel> enderecos;
        private ObservableCollection<ContaEnderecoViewModel> Enderecos
        {
            get { return enderecos; }
            set { enderecos = value; Notify(); }
        }

        private string[] tiposDocumento;
        private string[] TiposDocumento
        {
            get { return Enum.GetNames(typeof(ETipoDocumento)); }
            set { tiposDocumento = value; Notify(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task<Cliente> GetCliente(Guid id_cliente)
        {
            WSService s = new WSService();
            var result = await s.Get<Cliente>(Constantes.SERVER_CLIENTES + id_cliente.ToString());
            if (result.GetType() == typeof(Response))
            {
                var response = (Response)result;
                Message.Erro((string)response.Data);
                return null;
            }

            return result as Cliente;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var clientevm = e.Parameter as ClienteViewModel;

            Cliente cliente = await GetCliente(Guid.Parse("34871E1C-A6E2-422B-9BB9-75FF4B030B24"));

            var Edit = cliente != null;

            if (Edit)
            {
                ClienteViewModel = new ClienteViewModel(cliente);
                AdicionaEnderecosEContatos(ClienteViewModel);
            }
            else
            {
                var idTipoCliente = Guid.Parse("e8d735c4-a499-4ff3-9fdd-421c492dd543");
                ClienteViewModel = new ClienteViewModel(new Cliente("", idTipoCliente));
            }

            base.OnNavigatedTo(e);

        }

        private void AdicionaEnderecosEContatos(ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel.Cliente.Enderecos != null && clienteViewModel.Cliente.Enderecos.Any())
            {
                var enderecosViewModel = from endereco in clienteViewModel.Cliente.Enderecos
                                         select new ContaEnderecoViewModel(endereco);

                Enderecos = new ObservableCollection<ContaEnderecoViewModel>(enderecosViewModel);
                lv_enderecos.ItemsSource = Enderecos;
            }

            if (clienteViewModel.Cliente.Contatos != null && clienteViewModel.Cliente.Contatos.Any())
            {
                var contatosViewModel = from contato in clienteViewModel.Cliente.Contatos
                                        select new ContaContatoViewModel(contato);

                Contatos = new ObservableCollection<ContaContatoViewModel>(contatosViewModel);
                lv_contatos.ItemsSource = Contatos;
            }
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

        private async void abb_novoEndereco_Click(object sender, RoutedEventArgs e)
        {
            ContaEnderecoContentDialog ce = new ContaEnderecoContentDialog();
            ce.SalvaEnderecoHandler += Ce_SalvaEnderecoHandler;
            await ce.ShowAsync();
        }

        private async void Ce_SalvaEnderecoHandler(object sender, Handlers.Enderecos.ContaEnderecoHandler args)
        {
            var wsEntityService = new WSEntityService<ContaEndereco>(Constantes.SERVER_CONTAS_ENDERECO);

            if (!args.Edit && !Edit)
            {
                enderecos.Add(new ContaEnderecoViewModel(args.ContaEndereco));
                return;
            }

            if (args.Edit && !Edit) return;

            if (Edit && args.Edit)
            {
                await wsEntityService.Atualiza(args.ContaEndereco);
                return;
            }

            if (Edit && !args.Edit)
            {
                args.ContaEndereco.Id_conta = clienteViewModel.Cliente.Id.Value;
                await wsEntityService.Cria(args.ContaEndereco);
                return;
            }
        }

        private async void Cc_SalvaContatoHandler(object sender, Handlers.Contatos.ContaContatoHandler args)
        {
            var wsEntityService = new WSEntityService<ContaContato>(Constantes.SERVER_CONTAS_CONTATO);

            if (!args.Edit && !Edit)
            {
                contatos.Add(new ContaContatoViewModel(args.ContaContato));
                return;
            }

            if (args.Edit && !Edit)
            {
                var contatoOld = contatos.FirstOrDefault(c => c.ContaContato.Id == args.ContaContato.Id);
                contatoOld = new ContaContatoViewModel(args.ContaContato);
            };

            if (Edit && args.Edit)
            {
                await wsEntityService.Atualiza(args.ContaContato);
                return;
            }

            if (Edit && !args.Edit)
            {
                args.ContaContato.Id_conta = clienteViewModel.Cliente.Id.Value;
                try
                {
                    await wsEntityService.Cria(args.ContaContato);
                    var contatoOld = contatos.FirstOrDefault(c => c.ContaContato.Id == args.ContaContato.Id);
                    contatoOld = new ContaContatoViewModel(args.ContaContato);

                }
                catch { }

                return;
            }
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
            ContaContatoEditContentDialog cc = new ContaContatoEditContentDialog(contaContato, true);
            cc.SalvaContatoHandler += Cc_SalvaContatoHandler;
            await cc.ShowAsync();
        }

        private async void abb_salvar_Click(object sender, RoutedEventArgs e)
        {
            if (!Edit)
            {
                if (contatos.Any()) clienteViewModel.Cliente.Contatos = (from contato in contatos.ToList() select contato.ContaContato).ToList();
                if (enderecos.Any()) clienteViewModel.Cliente.Enderecos = (from endereco in enderecos.ToList() select endereco.ContaEndereco).ToList();

            }

            WSService ws = new WSService();
            var result = await ws.Post(Constantes.SERVER_CLIENTES, clienteViewModel.Cliente);
        }

        private void abb_cancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void lv_enderecos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var endereco = e.ClickedItem as ContaEnderecoViewModel;
            ContaEnderecoContentDialog ce = new ContaEnderecoContentDialog(endereco, true);
            ce.SalvaEnderecoHandler += Ce_SalvaEnderecoHandler;
            await ce.ShowAsync();
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
