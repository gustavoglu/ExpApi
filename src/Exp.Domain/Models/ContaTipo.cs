using Exp.Domain.Core.Models;
using System.Collections.Generic;

namespace Exp.Domain.Models
{
    public class ContaTipo : Entity
    {
        private ContaTipo(){ }

        public ContaTipo(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; }

        public IEnumerable<Conta> Contas { get; set; }
    }
}
