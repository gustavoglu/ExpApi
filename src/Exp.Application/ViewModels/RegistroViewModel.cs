using Exp.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Exp.Application.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Obrigatório informar o Login")]
        [EmailAddress(ErrorMessage = "Login precisa ser um e-mail")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Confirmação da Senha")]
        [Compare("Senha", ErrorMessage = "A Senha e a Confirmação da Senha precisam ser iguais")]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Sobrenome")]
        public string Sobrenome { get; set; }

        public string Telefone { get; set; }

        public string TelefoneAdicional { get; set; }

        public string Documento { get; set; }

        public ETipoDocumento? TipoDocumento { get; set; }

        public Guid? Id_contaTipo { get; set; }

        public string Departamento { get; set; }

        public string Funcao { get; set; }
    }
}
