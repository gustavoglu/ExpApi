using Exp.Domain.Models;
using System;
using System.ComponentModel;

namespace Exp.UWP.ViewModels
{
    public class ContaEnderecoViewModel : INotifyPropertyChanged
    {
        public ContaEndereco ContaEndereco { get; private set; }

        public ContaEnderecoViewModel(ContaEndereco contaEndereco)
        {
            ContaEndereco = contaEndereco;
        }

        public Guid? Id { get { return ContaEndereco.Id; } }
        public string Rua { get { return ContaEndereco.Rua; } set { ContaEndereco.Rua = value; Notify(nameof(Rua)); } }
        public string Numero { get { return ContaEndereco.Numero; } set { ContaEndereco.Numero = value; Notify(nameof(Numero)); } }
        public string Complemento { get { return ContaEndereco.Complemento; } set { ContaEndereco.Complemento = value; Notify(nameof(Complemento)); } }
        public string Bairro { get { return ContaEndereco.Bairro; } set { ContaEndereco.Bairro = value; Notify(nameof(Bairro)); } }
        public string Cidade { get { return ContaEndereco.Cidade; } set { ContaEndereco.Cidade = value; Notify(nameof(Cidade)); } }
        public string Estado { get { return ContaEndereco.Estado; } set { ContaEndereco.Estado = value; Notify(nameof(Estado)); } }
        public string Pais { get { return ContaEndereco.Pais; } set { ContaEndereco.Pais = value; Notify(nameof(Pais)); } }


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
