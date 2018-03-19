using Exp.Domain.Core.Models;
using Exp.Domain.Enums;
using Exp.Domain.Models;
using Exp.UWP.EntityServices;
using Exp.UWP.WS;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Exp.UWP.ViewModels.Clientes
{
    public abstract class ClientePageViewModel : INotifyPropertyChanged
    {
        public ClientePageViewModel(ClienteViewModel clienteViewModel)
        {
            this.ClienteViewModel = clienteViewModel;
        }

        private bool edit;

        public bool Edit
        {
            get { return edit; }
            set { edit = value; Notify(); }
        }

        private ClienteViewModel clienteViewModel;

        protected ClienteViewModel ClienteViewModel
        {
            get { return clienteViewModel; }
            set { clienteViewModel = value; Notify(); }
        }

        private ObservableCollection<ContaContatoViewModel> contatos;
        protected ObservableCollection<ContaContatoViewModel> Contatos
        {
            get { return contatos; }
            set { contatos = value; Notify(); }
        }

        private ObservableCollection<ContaEnderecoViewModel> enderecos;
        protected ObservableCollection<ContaEnderecoViewModel> Enderecos
        {
            get { return enderecos; }
            set { enderecos = value; Notify(); }
        }

        private string[] tiposDocumento;
        protected string[] TiposDocumento
        {
            get { return Enum.GetNames(typeof(ETipoDocumento)); }
            set { tiposDocumento = value; Notify(); }
        }

        protected abstract void NovoEndereco();
        protected abstract void SalvarEndereco(ContaEndereco endereco);
        protected abstract void DeletaEndereco(ContaEndereco endereco);
        protected abstract void NovoContato();
        protected abstract void SalvarContato(ContaContato contato);
        protected abstract void DeletaContato(ContaContato contato);

        protected async Task SalvaCliente(Cliente cliente, bool edit = false)
        {
            WSEntityService<Cliente> wsservice = new WSEntityService<Cliente>(Constantes.SERVER_CLIENTES);

            if (!edit)
                await wsservice.Cria(cliente);
            else
                await wsservice.Atualiza(cliente);
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task NavigationService(ClienteViewModel clientevm = null)
        {
            Cliente cliente = await GetCliente(Guid.Parse("34871E1C-A6E2-422B-9BB9-75FF4B030B24"));

            Edit = cliente != null;

            if (Edit) ClienteViewModel = new ClienteViewModel(cliente);

            if (!Edit)
            {
                var idTipoCliente = Guid.Parse("e8d735c4-a499-4ff3-9fdd-421c492dd543");
                ClienteViewModel = new ClienteViewModel(new Cliente("Teste", idTipoCliente));
            }

            if (ClienteViewModel.Cliente.Enderecos != null && ClienteViewModel.Cliente.Enderecos.Any())
            {
                var enderecosViewModel = from endereco in ClienteViewModel.Cliente.Enderecos
                                         select new ContaEnderecoViewModel(endereco);

                enderecos = new ObservableCollection<ContaEnderecoViewModel>(enderecosViewModel);
            }

            if (ClienteViewModel.Cliente.Contatos != null && ClienteViewModel.Cliente.Contatos.Any())
            {
                var contatosViewModel = from contato in ClienteViewModel.Cliente.Contatos
                                        select new ContaContatoViewModel(contato);

                contatos = new ObservableCollection<ContaContatoViewModel>(contatosViewModel);
            }

        }
    }
}
