using Microsoft.EntityFrameworkCore;
using SupplierDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierDelivery.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ProdutoEntity> Produto { get; set; }
        public DbSet<FornecedorEntity> Fornecedor { get; set; }
        public DbSet<EntregaEntity> Entrega { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<ProdutoEntity>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Nome).IsRequired().HasMaxLength(100);
                b.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<FornecedorEntity>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.RazaoSocial).IsRequired().HasMaxLength(200);
                b.Property(x => x.NomeFantasia).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<EntregaEntity>(b =>
            {
                b.HasKey(e => e.Id);
                b.HasOne(e => e.Fornecedor)
                 .WithMany(f => f.Entregas)
                 .HasForeignKey(e => e.FornecedorId)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(e => e.Produto)
                 .WithMany(p => p.Entregas)
                 .HasForeignKey(e => e.ProdutoId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
