using Exp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exp.Infra.Data.Mappings
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> b)
        {
            b.HasOne(cl => cl.Cliente)
                .WithMany(c => c.Colaboradores)
                .HasForeignKey(cl => cl.Id_cliente)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}
