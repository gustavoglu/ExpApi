using Exp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exp.Infra.Data.Mappings
{
    public class ContaTipoMap : IEntityTypeConfiguration<ContaTipo>
    {
        public void Configure(EntityTypeBuilder<ContaTipo> b)
        {
            b.HasKey(ct => ct.Id);
        }
    }
}
