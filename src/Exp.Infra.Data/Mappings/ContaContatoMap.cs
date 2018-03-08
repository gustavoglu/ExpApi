using Exp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exp.Infra.Data.Mappings
{
    public class ContaContatoMap : IEntityTypeConfiguration<ContaContato>
    {
        public void Configure(EntityTypeBuilder<ContaContato> b)
        {
            b.HasKey(cc => cc.Id);

            b.HasOne(cc => cc.Conta)
                .WithMany(c => c.Contatos)
                .HasForeignKey(cc => cc.Id_conta)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

        }
    }
}
