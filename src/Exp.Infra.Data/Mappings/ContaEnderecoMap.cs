using Exp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exp.Infra.Data.Mappings
{
    public class ContaEnderecoMap : IEntityTypeConfiguration<ContaEndereco>
    {
        public void Configure(EntityTypeBuilder<ContaEndereco> b)
        {
            b.HasKey(ce => ce.Id);

            b.HasOne(cc => cc.Conta)
           .WithMany(c => c.Enderecos)
           .HasForeignKey(cc => cc.Id_conta)
           .OnDelete(DeleteBehavior.Cascade)
           .IsRequired();
        }
    }
}
