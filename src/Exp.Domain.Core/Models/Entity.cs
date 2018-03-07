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
    }
}
