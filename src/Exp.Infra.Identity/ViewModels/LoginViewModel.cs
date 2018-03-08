using System.ComponentModel.DataAnnotations;

namespace Exp.Infra.Identity.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Obrigatório informar o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        public string Senha { get; set; }
    }
}
