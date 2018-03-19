using Exp.Domain.Enums;
using Exp.Domain.Models;
using System;
using System.ComponentModel;

namespace Exp.UWP.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        public Cliente Cliente { get; set; }

        public ClienteViewModel(Cliente cliente)
        {
            Cliente = cliente;
        }

        public string RazaoSocial { get { return Cliente.RazaoSocial; } set { Cliente.RazaoSocial = value; Notify(nameof(RazaoSocial)); } }

        public string Nome { get { return Cliente.Nome; } set { Cliente.Nome = value; Notify(nameof(Nome)); } }

        public string Email { get { return Cliente.Email; } set { Cliente.Email = value; Notify(nameof(Email)); } }

        public string Telefone { get { return Cliente.Telefone; } set { Cliente.Telefone = value; Notify(nameof(Telefone)); } }

        public string TelefoneAdicional { get { return Cliente.TelefoneAdicional; } set { Cliente.TelefoneAdicional = value; Notify(nameof(TelefoneAdicional)); } }

        public string Documento { get { return Cliente.Documento; } set { Cliente.Documento = value; Notify(nameof(Documento)); } }

        public ETipoDocumento? TipoDocumento { get { return Cliente.TipoDocumento; } set { Cliente.TipoDocumento = value; } }

        public Guid Id_contaTipo { get { return Cliente.Id_contaTipo; } set { Cliente.Id_contaTipo = value; Notify(nameof(Id_contaTipo)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotificarPropertys()
        {
            Notify(nameof(RazaoSocial));
            Notify(nameof(Nome));
            Notify(nameof(Email));
            Notify(nameof(Telefone));
            Notify(nameof(TelefoneAdicional));
            Notify(nameof(Documento));
            Notify(nameof(TipoDocumento));
            Notify(nameof(Id_contaTipo));
        }

        public static implicit operator ClienteViewModel(Cliente v)
        {
            throw new NotImplementedException();
        }
    }
}
