using System;

namespace Exp.Domain.Core.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? CriadoEm { get; set; }
        public string AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string DeletadoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public bool Deletado { get; set; } = false;

        public void SetId(Guid id)
        {
            this.Id = id;
        }

        public void AtribuirCriacao(string criadoPor)
        {
            this.CriadoEm = DateTime.Now;
            this.CriadoPor = criadoPor;
        }

        public void AtribuirAtualizacao (string atualizadoPor)
        {
            this.AtualizadoEm = DateTime.Now;
            this.AtualizadoPor = atualizadoPor;
        }

        public void AtribuirDelecao(string deletadoPor)
        {
            this.AtualizadoPor = deletadoPor;
            this.AtualizadoEm = DateTime.Now;
            this.DeletadoEm = DateTime.Now;
            this.DeletadoPor = deletadoPor;
            this.Deletado = true;
        }

    }
}
