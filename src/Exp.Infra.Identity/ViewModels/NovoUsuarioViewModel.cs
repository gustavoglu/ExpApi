using System.ComponentModel.DataAnnotations;

namespace Exp.Infra.Identity.ViewModels
{
    public class NovoUsuarioViewModel
    {
        [Required(ErrorMessage = "Obrigatório informar o Login")]
        [EmailAddress(ErrorMessage = "Login precisa ser um e-mail")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Confirmação da Senha")]
        [Compare("Senha",ErrorMessage = "A Senha e a Confirmação da Senha precisam ser iguais")]
        public string ConfirmacaoSenha { get; set; }
    }
}
