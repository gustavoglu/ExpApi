using Exp.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exp.Infra.Data.Context
{
    public class ContextSQLS : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(builder.GetConnectionString(""));
        }

        public override int SaveChanges()
        {
            var adicionados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Added);
            var atualizados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Modified);
            var deletados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Deleted);

            if (adicionados.Any()) AdicionaEntitys(adicionados);
            if (atualizados.Any()) AtualizaEntitys(atualizados);
            if (deletados.Any()) DeletaEntitys(deletados);

            return base.SaveChanges();
        }

        private void AdicionaEntitys(IEnumerable<EntityEntry> adicionados)
        {

        }
        private void AtualizaEntitys(IEnumerable<EntityEntry> atualizados)
        {

        }
        private void DeletaEntitys(IEnumerable<EntityEntry> deletados)
        {

        }
    }
    
}
