using Exp.Domain.Core.Models;
using Exp.Domain.Interfaces.UserIdentity;
using Exp.Domain.Models;
using Exp.Infra.Data.Mappings;
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
        private readonly IUser _user;

        public ContextSQLS(IUser user)
        {
            _user = user;
        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaContato> ContaContatos { get; set; }
        public DbSet<ContaEndereco> ContaEnderecos { get; set; }
        public DbSet<ContaTipo> ContaTipos { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContaMap());
            modelBuilder.ApplyConfiguration(new ContaContatoMap());
            modelBuilder.ApplyConfiguration(new ContaEnderecoMap());
            modelBuilder.ApplyConfiguration(new ContaTipoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ColaboradorMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=exp_db;Trusted_Connection=True;MultipleActiveResultSets=true");
            
        }

        public override int SaveChanges()
        {
            var adicionados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Added);
            var atualizados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Modified);
            var deletados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Deleted);

            try
            {
                if (adicionados.Any()) AdicionaEntitys(adicionados);
                if (atualizados.Any()) AtualizaEntitys(atualizados);
                if (deletados.Any()) DeletaEntitys(deletados);

            }
            catch { }

            return base.SaveChanges();
        }

        private void AdicionaEntitys(IEnumerable<EntityEntry> adicionados)
        {
            foreach (var adicionado in adicionados)
            {
                var entity = (Entity)adicionado.Entity;
                entity.AtribuirCriacao(_user.UserNameLogado());
            }
        }
        private void AtualizaEntitys(IEnumerable<EntityEntry> atualizados)
        {
            foreach (var atualizado in atualizados)
            {
                atualizado.Property("CriadoEm").IsModified = false;
                atualizado.Property("CriadoPor").IsModified = false;
                var entity = (Entity)atualizado.Entity;
                entity.AtribuirAtualizacao(_user.UserNameLogado());
            }
        }
        private void DeletaEntitys(IEnumerable<EntityEntry> deletados)
        {
            foreach (var deletado in deletados)
            {
                deletado.State = EntityState.Modified;
                deletado.Property("CriadoEm").IsModified = false;
                deletado.Property("CriadoPor").IsModified = false;
                deletado.Property("AtualizadoEm").IsModified = false;
                deletado.Property("AtualizadoPor").IsModified = false;
                var entity = (Entity)deletado.Entity;
                entity.AtribuirDelecao(_user.UserNameLogado());
            }
        }
    }

}
