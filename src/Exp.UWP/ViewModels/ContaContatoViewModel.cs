using Exp.Domain.Models;
using System;
using System.ComponentModel;

namespace Exp.UWP.ViewModels
{
    public class ContaContatoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ContaContato ContaContato { get; private set; }

        public ContaContatoViewModel(ContaContato contaContato)
        {
            ContaContato = contaContato;
        }

        public Guid? Id { get { return ContaContato.Id; } }
        public string Nome { get { return ContaContato.Nome; } set { ContaContato.Nome = value; } }
        public string Email { get { return ContaContato.Email; } set { ContaContato.Email = value;  } }
        public string Funcao { get { return ContaContato.Funcao; } set { ContaContato.Funcao = value;  } }
        public string Telefone { get { return ContaContato.Telefone; } set { ContaContato.Telefone = value; } }
        public string TelefoneAdicional { get { return ContaContato.TelefoneAdicional; } set { ContaContato.TelefoneAdicional = value; } }
        public string Observacoes { get { return ContaContato.Observacoes; } set { ContaContato.Observacoes = value;} }

        private void Notify(string propertyname)
        {
            if(propertyname != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
