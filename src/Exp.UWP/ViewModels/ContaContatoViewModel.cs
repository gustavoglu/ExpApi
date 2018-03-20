using Exp.Domain.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Exp.UWP.ViewModels
{
    public class ContaContatoViewModel : INotifyPropertyChanged,IEditableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ContaContato ContaContato { get; private set; }
        private ContaContatoViewModel Old;

        public ContaContatoViewModel(ContaContato contaContato)
        {
            ContaContato = contaContato;
        }

        public Guid? Id { get { return ContaContato.Id; } }
        public string Nome { get { return ContaContato.Nome; } set { ContaContato.Nome = value; Notify(); } }
        public string Email { get { return ContaContato.Email; } set { ContaContato.Email = value; Notify(); } }
        public string Funcao { get { return ContaContato.Funcao; } set { ContaContato.Funcao = value; Notify(); } }
        public string Telefone { get { return ContaContato.Telefone; } set { ContaContato.Telefone = value; Notify(); } }
        public string TelefoneAdicional { get { return ContaContato.TelefoneAdicional; } set { ContaContato.TelefoneAdicional = value; Notify(); } }
        public string Observacoes { get { return ContaContato.Observacoes; } set { ContaContato.Observacoes = value; Notify(); } }

        private void Notify([CallerMemberName]string propertyname = null)
        {
            if (propertyname != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));

        }

        public void BeginEdit()
        {
            Old = this.MemberwiseClone() as ContaContatoViewModel;
        }

        public void CancelEdit()
        {
            this.Nome = Old.Nome;
            this.Email = Old.Email;
            this.Funcao = Old.Funcao;
            this.Telefone = Old.Telefone;
            this.TelefoneAdicional = Old.TelefoneAdicional;
            this.Observacoes = Old.Observacoes;
        }

        public void EndEdit()
        {
            return;
        }
    }
}
