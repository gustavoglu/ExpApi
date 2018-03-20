using Exp.Domain.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Exp.UWP.ViewModels
{
    public class ContaEnderecoViewModel : INotifyPropertyChanged, IEditableObject
    {
        public ContaEndereco ContaEndereco { get; private set; }
        public ContaEnderecoViewModel Old;

        public ContaEnderecoViewModel(ContaEndereco contaEndereco)
        {
            ContaEndereco = contaEndereco;
            this.Id = ContaEndereco.Id;
            this.Rua = ContaEndereco.Rua;
            this.Numero = ContaEndereco.Numero;
            this.Cidade = ContaEndereco.Cidade;
            this.Estado = ContaEndereco.Estado;
            this.Pais = ContaEndereco.Pais;
            this.Complemento = ContaEndereco.Complemento;
        }

        public Guid? Id { get; set; }
        private string rua;
        public string Rua
        {
            get { return rua; }
            set { rua = value;Notify(); }
        }

        private string numero;
        public string Numero
        {
            get { return numero; }
            set { numero = value; Notify(); }
        }

        private string bairro;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; Notify(); }
        }

        private string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; Notify(); }
        }

        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; Notify(); }
        }

        private string pais;
        public string Pais
        {
            get { return pais; }
            set { pais = value; Notify(); }
        }

        private string complemento;
        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; Notify(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify([CallerMemberName]string propertyName = null)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void BeginEdit()
        {
            Old = (ContaEnderecoViewModel)this.MemberwiseClone();
        }

        public void CancelEdit()
        {
            this.Rua = Old.Rua;
            this.Numero = Old.Numero;
            this.Bairro = Old.Bairro;
            this.Cidade = Old.Cidade;
            this.Estado = Old.Estado;
            this.Pais = Old.Pais;
            this.Complemento = Old.Complemento;

            ContaEndereco.Rua = Old.Rua;
            ContaEndereco.Numero = Old.Numero;
            ContaEndereco.Bairro = Old.Bairro;
            ContaEndereco.Cidade = Old.Cidade;
            ContaEndereco.Estado = Old.Estado;
            ContaEndereco.Pais = Old.Pais;
            ContaEndereco.Complemento = Old.Complemento;
        }

        public void EndEdit()
        {
            ContaEndereco.Rua = Rua;
            ContaEndereco.Numero = Numero;
            ContaEndereco.Bairro = Bairro;
            ContaEndereco.Complemento = Complemento;
            ContaEndereco.Cidade = Cidade;
            ContaEndereco.Estado = Estado;
            ContaEndereco.Pais = Pais;
        }
    }
}
