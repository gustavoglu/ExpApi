using System;

namespace Exp.Domain.Core.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid? Id { get; protected set; }
        public string CriadoPor { get; protected set; }
        public DateTime? CriadoEm { get; protected set; }
        public string AtualizadoPor { get; protected set; }
        public DateTime? AtualizadoEm { get; protected set; }
        public string DeletadoPor { get; protected set; }
        public DateTime? DeletadoEm { get; protected set; }
        public bool Deletado { get; protected set; } = false;

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
