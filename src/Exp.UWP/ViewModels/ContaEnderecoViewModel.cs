using Exp.Domain.Models;
using System;
using System.ComponentModel;

namespace Exp.UWP.ViewModels
{
    public class ContaEnderecoViewModel : INotifyPropertyChanged
    {
        private readonly ContaEndereco _contaEndereco;
        public ContaEnderecoViewModel(ContaEndereco contaEndereco)
        {
            _contaEndereco = contaEndereco;
        }

        public Guid? Id { get { return _contaEndereco.Id; } }
        public string Rua { get { return _contaEndereco.Rua; } set { _contaEndereco.Rua = value; Notify(nameof(Rua)); } }
        public string Numero { get { return _contaEndereco.Numero; } set { _contaEndereco.Numero = value; Notify(nameof(Numero)); } }
        public string Complemento { get { return _contaEndereco.Complemento; } set { _contaEndereco.Complemento = value; Notify(nameof(Complemento)); } }
        public string Bairro { get { return _contaEndereco.Bairro; } set { _contaEndereco.Bairro = value; Notify(nameof(Bairro)); } }
        public string Cidade { get { return _contaEndereco.Cidade; } set { _contaEndereco.Cidade = value; Notify(nameof(Cidade)); } }
        public string Estado { get { return _contaEndereco.Estado; } set { _contaEndereco.Estado = value; Notify(nameof(Estado)); } }
        public string Pais { get { return _contaEndereco.Pais; } set { _contaEndereco.Pais = value; Notify(nameof(Pais)); } }


        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
