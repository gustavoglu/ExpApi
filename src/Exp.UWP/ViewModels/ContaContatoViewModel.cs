using Exp.Domain.Models;
using System;
using System.ComponentModel;

namespace Exp.UWP.ViewModels
{
    public class ContaContatoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ContaContato _contaContato;
        public ContaContatoViewModel(ContaContato contaContato)
        {
            _contaContato = contaContato;
        }

        public Guid? Id { get { return _contaContato.Id; } }
        public string Nome { get { return _contaContato.Nome; } set { _contaContato.Nome = value; Notify(nameof(Nome)); } }
        public string Email { get { return _contaContato.Email; } set { _contaContato.Email = value; Notify(nameof(Email)); } }
        public string Funcao { get { return _contaContato.Funcao; } set { _contaContato.Funcao = value; Notify(nameof(Funcao)); } }
        public string Telefone { get { return _contaContato.Telefone; } set { _contaContato.Telefone = value; Notify(nameof(Telefone)); } }
        public string TelefoneAdicional { get { return _contaContato.TelefoneAdicional; } set { _contaContato.TelefoneAdicional = value; Notify(nameof(TelefoneAdicional)); } }
        public string Observacoes { get { return _contaContato.Observacoes; } set { _contaContato.Observacoes = value; Notify(nameof(Observacoes)); } }

        private void Notify(string propertyname)
        {
            if(propertyname != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
